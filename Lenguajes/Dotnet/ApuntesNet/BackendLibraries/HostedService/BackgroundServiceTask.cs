﻿using Microsoft.Extensions.Hosting;

namespace HostedService;

public class BackgroundServiceTask(IServicioInyectado servicioInyectado) : BackgroundService
{
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        return Task.Run(async () =>
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine("Este es el metodo de Start");
                var counter = await servicioInyectado.ExecuteAsync(stoppingToken);
                Console.WriteLine(counter);
                await Task.Delay(1100, stoppingToken);
            }
        });
    }
}
