using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SerilogLibrary;

var serviceProvider = Helper.GetServiceProvider();

var logger = serviceProvider.GetRequiredService<ILogger<Program>>();

logger.LogDebug("Log para Depuracion");
logger.LogInformation("Log para Informacion");
logger.LogWarning("Log para trazas importantes");
logger.LogError("Log para errores");
logger.LogCritical("Log generalmente para excepciones");

// Implementar un objeto entero en log
var user = new UserDTO
{
    Name = "Prueba",
    SurName = "Logger",
    Email = "Prueba@logger.com",
    MerchantId = "1234567890",
    TerminalId = "0000000001"
};
logger.LogInformation("Datos de usuario {@userData}", user);


Console.Read();
