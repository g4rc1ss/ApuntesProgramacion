using DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HostedService;

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
