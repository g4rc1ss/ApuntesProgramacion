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
