using DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddTransient<IServicioInyectado, ServicioInyectado>();

var serviceProvider = services.BuildServiceProvider();

var servicio = serviceProvider.GetRequiredService<IServicioInyectado>();

await servicio.ExecuteAsync();
