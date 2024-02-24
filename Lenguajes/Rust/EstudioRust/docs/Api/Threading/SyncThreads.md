# Sincronizacion de hilos
Con el uso de la sincronizacion podremos establecer el orden de ejecucion de los hilos en el procesador para poder tener una mejor gestion sobre estos

## Join
El metodo Join correspondiente a una clase `Thread` hace que se espere a que termine la ejecucion del hilo antes de seguir con el codigo siguiente.

```Csharp
var hilo1 = new Thread(() =>
{
    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine($"Hilo 1 {i}");
    }
});
hilo1.Start();
hilo1.Join();
Thread.Sleep(1000);
```

## lock()
El uso del metodo `lock` se usa para indicar a los subprocesos que han de esperar a que acabe el hilo que esta en ejecucion dentro del bloque de instruccion.

Para poder hacer uso de `lock`, se tiene que crear un objeto instaciado de la clase `object` y agregarlo como parametro.

Cuando ejecutamos codigo externo al que se esta procesando en el nuevo hilo, por ejemplo, creamos varios `Thread` que suman una variable que ambos comparten, puede que los hilos accedan a la vez a modificar dicho valor. A este problema se le llama **condicion de carrera**. Para evitarlo se hace uso de la instruccion `lock`
```Csharp
private object bloqueoAgregarCantidad = new object();

public void AgregarCantidad(int dinero)
{
    lock (bloqueoAgregarCantidad)
    {
        Cantidad += dinero;
    }
}
```

