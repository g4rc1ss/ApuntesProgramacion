using DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HostedService;

public class BackgroundServiceTask : BackgroundService
{
    private readonly IServicioInyectado _servicioInyectado;

    public BackgroundServiceTask(IServicioInyectado servicioInyectado)
    {
        _servicioInyectado = servicioInyectado;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        return Task.Run(async () =>
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine("Este es el metodo de Start");
                var counter = await _servicioInyectado.ExecuteAsync(stoppingToken);
                Console.WriteLine(counter);
                await Task.Delay(1100, stoppingToken);
            }
        });
    }
}
