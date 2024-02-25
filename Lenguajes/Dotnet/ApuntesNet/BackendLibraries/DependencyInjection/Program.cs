using DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddTransient<PServicioInyectado, ServicioInyectado>();

var serviceProvider = services.BuildServiceProvider();

var servicio = serviceProvider.GetRequiredService<PServicioInyectado>();

await servicio.ExecuteAsync();
