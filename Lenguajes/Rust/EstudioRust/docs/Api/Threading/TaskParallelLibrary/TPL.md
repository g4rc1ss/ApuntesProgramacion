La biblioteca TPL (Task Parallel Library, biblioteca de procesamiento paralelo basado en tareas) es un conjunto de API y tipos públicos de los espacios de nombres System.Threading y System.Threading.Tasks. El propósito de la TPL es aumentar la productividad de los desarrolladores simplificando el proceso de agregar paralelismo y simultaneidad a las aplicaciones. La TPL escala el grado de simultaneidad de manera dinámica para usar con mayor eficacia todos los procesadores disponibles. Además, la TPL se encarga de la división del trabajo, la programación de los subprocesos en ThreadPool, la compatibilidad con la cancelación, la administración de los estados y otros detalles de bajo nivel. Al utilizar la TPL, el usuario puede optimizar el rendimiento del código mientras se centra en el trabajo para el que el programa está diseñado.

# Paralelizacion
Las operaciones **asincronas** estan centradas en usar un mismo hilo para la ejecucion de operaciones **E/S**, de esta manera permite mayor **escalabilidad**.

Las operaciones **Parallel** estan mas centradas en usar multiples hilos, puesto que tienen que realizar procesamiento enlazado a la **CPU**.

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

