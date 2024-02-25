using AutomapperLibrary;

using Microsoft.Extensions.DependencyInjection;


var serviceProvider = Helper.GetServiceProvider();

var autoMapping = serviceProvider.GetRequiredService<AutoMappingClasses>();
autoMapping.Mapping();


Console.WriteLine("Pulsa una tecla para terminar...");
Console.Read();
