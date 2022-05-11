using AutomapperLibrary;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var serviceProvider = Helper.GetServiceProvider();

var logger = serviceProvider.GetRequiredService<ILogger<Program>>();

logger.LogDebug("Log para Depuracion");
logger.LogInformation("Log para Informacion");
logger.LogWarning("Log para trazas importantes");
logger.LogError("Log para errores");
logger.LogCritical("Log generalmente para excepciones");

Console.Read();
