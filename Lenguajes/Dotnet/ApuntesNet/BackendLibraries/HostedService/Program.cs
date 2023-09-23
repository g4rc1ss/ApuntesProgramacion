using DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureServices(services =>
{
    services.AddSingleton<IServicioInyectado, ServicioInyectado>();
    services.AddHostedService<HostedService.HostedService>();
});

var app = builder.Build();

await app.StartAsync();
