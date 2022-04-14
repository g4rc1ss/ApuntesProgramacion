La biblioteca TPL (Task Parallel Library, biblioteca de procesamiento paralelo basado en tareas) es un conjunto de API y tipos públicos de los espacios de nombres System.Threading y System.Threading.Tasks. El propósito de la TPL es aumentar la productividad de los desarrolladores simplificando el proceso de agregar paralelismo y simultaneidad a las aplicaciones. La TPL escala el grado de simultaneidad de manera dinámica para usar con mayor eficacia todos los procesadores disponibles. Además, la TPL se encarga de la división del trabajo, la programación de los subprocesos en ThreadPool, la compatibilidad con la cancelación, la administración de los estados y otros detalles de bajo nivel. Al utilizar la TPL, el usuario puede optimizar el rendimiento del código mientras se centra en el trabajo para el que el programa está diseñado.


# Programación Asincrona
La programacion asincrona se realiza cuando se quieren evitar bloqueos en el hilo principal de la aplicación, cuando se realiza una operacion que requiere tiempo de procesamiento, el hilo sobre el que se esta ejecutando se bloquea hasta que termine, eso causa que la aplicacion no responda a mas operaciones.

Por ejemplo, en una interfaz Desktop, si se usa el patron en las operaciones costosas, la interfaz no se bloqueará mientras se ejecutan las instrucciones.  
En una aplicacion web como `ASP.NET` usar el patron hara que se puedan recibir mas peticiones mientras las peticiones anteriores estan en espera de que termine el proceso que ocupa tiempo, como por ejemplo, una consulta a BBDD.

## Async & Await
El núcleo de la programación asincrona son los objetos `Task` y `Task<T>`, que modelan las operaciones asincronas. Son compatibles con las palabras clave `async` y `await`. El modelo es bastante sencillo en la mayoría de los casos:

- Para el código enlazado a E/S, espera una operación que devuelva `Task` o `Task<T>` dentro de un método async.
- Para el código enlazado a la CPU, espera una operación que se inicia en un subproceso en segundo plano con el método `Task.Run`.

La palabra clave `await` es donde ocurre la magia. Genera control para el autor de la llamada del método que ha realizado `await`, y permite una interfaz de usuario con capacidad de respuesta o un servicio flexible.

Su funcionamiento consiste en lo siguiente.

1. Hilos en el IOCP
1. Estamos esperando a una operacion asincrona, por ejemplo, lectura de un fichero de disco. Se pasa el thread al **IOCP**(threads que se mantienen a la espera), se inicia la operacion I/O, se crea la maquina de estados y se retorna un objeto `Task` a nuestro codigo.
1. Se espera a que termine la operacion I/O.
1. Se señala el IOCP.
1. El IOCP hace un callback para enviar la respuesta, se añade el resultado a la maquina de estados y se ejecuta el `TrySetResult`, se marcara la tarea como `Completed` y obtendremos el resultado solicitado en nuestro codigo. 
![image](https://user-images.githubusercontent.com/28193994/148436299-fba37b44-9af8-49ab-b4c5-cff9f7cc15d0.png)

Cuando ejecutamos la instruccion await, se nos genera codigo de bajo nivel de forma invisible, que crea y ejecuta una maquina de estados que se encarga de comprobar si la tarea fue ejecutada.

Un codigo que nosotros hacemos tan sencillo como lo siguiente:
```Csharp
private static async Task<string> GetWebData()
{
    BeforeTaskCreation();
    var task = new HttpClient().GetStringAsync(new Uri("https://www.google.es"));
    AfterTaskCreation();
    var result = await task;
    AfterAwaitTask(result);
    return result;
}
```
Genera el siguiente resultado.

1. Crea una estructura que implementa una interface `IAsyncStateMachine`
1. Declara variables para la maquina de estados
1. Declara el metodo MoveNext(), cuando se ejecuta el `default` lo que hace es ejecutar la funcion asincrona que queriamos y va obteniendo el awaiter, si no es completada, ira cambiando el estado y sera llamado de nuevo mas adelante hasta que sea completo, cuando eso pase, se acabará la ejecucion del switch y se retornará el resultado que queremos.

```Csharp
private struct AsyncStateMachine : IAsyncStateMachine
{
    public int CurrentState;
    public AsyncTaskMethodBuilder<string> Builder;
    public Task<string> Task;
    public string Result;
    private TaskAwaiter<string> awaiter;

    void IAsyncStateMachine.MoveNext()
    {
        string currentResult = null;
        try
        {
            bool flag = true;
            TaskAwaiter<string> awaiter;
            switch (this.CurrentState)
            {
                case -3:
                    goto label_6;
                case 0:
                    awaiter = this.awaiter;
                    this.awaiter = new TaskAwaiter<string>();
                    this.CurrentState = -1;
                    break;
                default:
                    this.Task = new HttpClient().GetStringAsync(new Uri("https://www.google.es"));
                    awaiter = this.Task.GetAwaiter();
                    if (!awaiter.IsCompleted)
                    {
                        this.CurrentState = 0;
                        this.awaiter = awaiter;
                        this.Builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, AsyncStateMachine>(ref awaiter, ref this);
                        flag = false;
                        return;
                    }
                    break;
            }
            string result = awaiter.GetResult();
            awaiter = new TaskAwaiter<string>();
            this.Result = result;
            currentResult = this.Result;
        }
        catch (Exception ex)
        {
            this.CurrentState = -2;
            this.Builder.SetException(ex);
            return;
        }

    label_6:
        this.CurrentState = -2;
        this.Builder.SetResult(currentResult);
    }

    void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine param0)
    {
        this.Builder.SetStateMachine(param0);
    }
}
```

1. Creamos una instancia de la estructura de maquina de estado.
1. Creamos una instancia de `AsyncTaskMethodBuilder`
1. Indica que el estado es -1
1. Inicia la maquina de estados
1. Retorna el resultado
```Csharp
private static Task<string> GetWebData()
{
    AsyncStateMachine stateMachine = new AsyncStateMachine();
    stateMachine.Builder = AsyncTaskMethodBuilder<string>.Create();
    stateMachine.CurrentState = -1;
    stateMachine.Builder.Start<AsyncStateMachine>(ref stateMachine);
    return stateMachine.Builder.Task;
}
```

### Async Eliding
Visto el codigo anterior, aparte de darnos cuenta de que la magia no existe, se ve que, aunque el uso de await nos da mas escalabilidad, requiere de mas proceso a lo tonto, al final, para nosotros solo es una palabra, ¿no?.

Generalmente cuando creamos una operacion asincrona, es asincrona hasta lo mas profundo de nuestro codigo, esto no es algo malo, pero hay que tener en cuenta que si en ese codigo se usan, por ejemplo, 5 await, se van a crear 5 maquinas de estado para el control de ese await y muchas veces, hacemos un await con un return. Eso provoca un procesamiento innecesario.

No siempre es posible, pero usando el siguiente codigo de ejemplo, podriamos evitar este problema.

- Creamos una maquina de estados para la ejecucion de `MetodoConAwait()`, cuando se llame al metodo, se creara otra maquina de estamos para la ejecucion de `Task.Delay`
- Creamos una maquina de estados para la ejecucion de `MetodoSinAwait()`, este metodo llamara a `Task.Delay` y la maquina de estados controlara su ejecucion.

Es importante saber analizar esto, puesto que en el caso de `result1` estamos generando 2 maquinas de estado cuando en el caso de `result2` estamos generando 1 y si ejecutamos el codigo veremos que ambas hacen exactamente el mismo resultado. Por tanto en el primer caso estamso generando codigo innecesario

```Csharp
public static async Task MetodoQueEjecuta()
{
    await MetodoConAwait();

    await MetodoSinAwait();
}


public static async Task MetodoConAwait()
{
    await Task.Delay(100000);
}

public static Task MetodoSinAwait()
{
    return Task.Delay(100000);
}
```


# Parallel
La clase estatica `Parallel` contiene los metodos `For`, `ForEach` e `Invoke` y se utiliza para hacer procesamiento multihilo de manera automatizada, su uso principal consta en el tratamiento de objetos como `Listas` o `Arrays` y la ejecucion de metodos en paralelo.

## Parallel Invoke
Permite la ejecucion paralelizada de un array de delegados

Cuando se ejecuta la instruccion, el metodo Invoke recibe un array de delegados que ejecutaran en un hilo nuevo y esperara a que estos terminen
```Csharp
Parallel.Invoke(
    () => objeto.Metodo1(),
    () =>
    {
        objeto = new Program();
    }
);
```

## Parallel For
Permite la ejecucion paralelizada de la lectura de una coleccion que implemente `IEnumerable`

```Csharp
Parallel.For(0, collection.Count, (x, state) =>
{
    Console.WriteLine($"Valor de la coleccion - {collection[x]} \n" +
        $"Estado del hilo {state.IsStopped}");
});
```
- El primer parámetro del método se envía el numero por el que se empieza
- El segundo parámetro se envía el numero final de la iteración
- En el tercer parámetro se envían 1 o 2 parámetros
    - `int`: que contendrá el número por el que va la iteración
    - `ParallelLoopState`: un objeto que se encargara de gestionar los      estados de los hilos, pudiendo parar la ejecución, etc.

## Parallel ForEach
El bucle paralelizado ForEach, permite leer una coleccion que implementa `IEnumerable` al igual que el bucle paralelizado For, la diferencia reside en que en ForEach obtienes ya el objeto del indice.

```Csharp
Parallel.ForEach(collection, (item, state, index) =>
{
    Console.WriteLine($"Valor de la coleccion - {item} \n" +
        $"Manipulacion de estado de los hilos {state.LowestBreakIteration} \n" +
        $"Indice en el que estamos posicionados actualmente - {index}");
});

await Parallel.ForEachAsync(Enumerable.Range(0, 10), async (value, token) =>
{
    await Task.Delay(2000);
    Console.WriteLine($"ForEachAsync NOMBRE  --  {value}");
});
```
- El primer parámetro se envía el objeto que queremos leer, un List<string> por ejemplo
- El segundo parámetro va la lambda que puede recibir dos parámetros
    - `obj` Contendrá un objeto del tipo de la lista y solo 1 elemento de dicha lista, es lo mismo que si a un array le hacemos un objetoArray[x] con un for normal.
    - `ParallelLoopState` Un objeto que se encargara de gestionar los estados de los hilos, pudiendo parar la ejecución, etc.
    - `index` Una propiedad que devuelve en que indice de la coleccion estamos.

# Paralelizacion
Las operaciones **asincronas** estan centrads en usar un mismo hilo para la ejecucion de operaciones **E/S**, de esta manera permite mayor **escalabilidad**.

Las operaciones **Parallel** estan mas centradas en usan multiples hilos, puesto que tienen que realizar procesamiento enlazado a la **cpu**.

## Ejemplos de uso de tipos de paralizacion
- Si queremos realizar varias consultas a base de datos de forma simultanea podemos hacer uso de las operaciones asincronas directamente.
    ```Csharp
    public Task<List<UserResponse>> GetListUsers()
    {
        using var context = _contextFactory.CreateDbContext();
        return context.User.ToListAsync();
    }
    ```
    - Suponiendo la ejecucion de multiples queries
        - Creamos una lista de tareas
        - Ejecutamos las tareas y las agregamos en la lista
        - Esperamos el resultado de las queries
    ```Csharp
    var tareas = new List<Task>();

    foreach (var item in Enumerable.Range(0, 10))
    {
        tareas.Add(userDam.GetListUsers());
    }
    await Task.WhenAll(tareas);
    ```

- Si queremos realiza operaciones costosas, por ejemplo, deserializar varios objetos grandes en memoria, leer estructuras de datos muy complejas, calculos muy grandes, debemos de usar el paralelismo por cpu.
    - Suponiendo que queremos calcular el coseno de una lista de elementos.  
    Si son pocos elementos no hace falta, pero si son una cantidad elevada, se podria considerar una carga bastante elevada a la cpu.
    ```Csharp
    Parallel.For(0, itemList.Count(), (i) =>
    {
        itemList[i] += (int)Math.Cos(i);
    });
    ```
    ![image](https://user-images.githubusercontent.com/28193994/148693892-581d79e0-1e8f-409b-bcee-d3fa3bad1a19.png)

