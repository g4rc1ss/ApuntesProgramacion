# Worker Services
En .net los Worker services son clases que se utilizan para crear procesos en segundo plano de larga duracion.

## Hosted Services
```Csharp
public class HostedService : IHostedService
{
    private readonly IServicioInyectado _servicioInyectado;

    public HostedService(IServicioInyectado servicioInyectado)
    {
        _servicioInyectado = servicioInyectado;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("Este es el metodo de Start");
            var counter = await _servicioInyectado.ExecuteAsync(cancellationToken);
            Console.WriteLine(counter);
            await Task.Delay(1100, cancellationToken);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Hola, este es el metodo Stop");
        return Task.CompletedTask;
    }
}
```
1. `StartAsync` Se ejecuta el proceso en un while para repetir el proceso en background y que se pueda ejecutar cada cierto tiempo. Es importante tener un `CancellationToken` y comprobar si este esta siendo cancelado para detener la tarea
2. `StopAsync` Metodo que se ejecuta para detener la tarea, por ejemplo, necesitas cerrar algun proceso o hacer alguna tarea

```Csharp
var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureServices(services =>
{
    services.AddSingleton<IServicioInyectado, ServicioInyectado>();
    services.AddHostedService<HostedService.HostedService>();
});

var app = builder.Build();

await app.StartAsync();
```
En el `Program.cs` configuramos la clase Host y agregamos el servicio mediante el metodo `services.AddHostedServices<HostedService>()`

Cuando ejecutamos el metodo `await app.StartAsync()` internamente se resuelven las dependencias de los `IHostedServices` y se ejecutan el metodo `StartAsync(CancellationToken cancellation)`
