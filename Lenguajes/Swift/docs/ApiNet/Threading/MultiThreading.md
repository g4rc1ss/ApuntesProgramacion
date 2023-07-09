Muchos equipos y estaciones de trabajo personales tienen varios núcleos de CPU que permiten ejecutar múltiples subprocesos simultáneamente. Para aprovecharse del hardware, se puede paralelizar el código para distribuir el trabajo entre dichos núcleos.

# Thread
Crea y controla un subproceso para procesar un codigo en otro hilo de ejecucion.
```Csharp
var hilo = new Thread(() =>
{
    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine($"Hilo {i}");
    }
});
hilo.Start();
```

# ThreadPool
Proporciona un grupo de subprocesos que pueden usarse para ejecutar tareas, exponer elementos de trabajo, procesar la E/S asincrona, esperar en nombre de otros subprocesos y procesar temporizadores.

Muchas aplicaciones crean subprocesos que invierten mucho tiempo en el estado inactivo, a la espera de que se produzca un evento. Otros subprocesos pueden entrar en un estado de inactividad que solo se activa periódicamente para sondear un cambio o información de estado de actualización. El grupo de subprocesos permite usar subprocesos de forma más eficaz al proporcionar a la aplicación un grupo de subprocesos de trabajo administrados por el sistema.

```Csharp
ThreadPool.QueueUserWorkItem(x =>
{
    Console.WriteLine($"Id Thread: {Thread.CurrentThread.ManagedThreadId}");
});
```
