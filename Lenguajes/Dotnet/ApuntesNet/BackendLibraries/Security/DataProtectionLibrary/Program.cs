using DataProtectionLibrary;
using DataProtectionLibrary.Protections;

using Microsoft.Extensions.DependencyInjection;


var serviceProvider = Helper.GetServiceProvider();

var dataProtect = serviceProvider.GetRequiredService<DataProtectionExample>();
dataProtect.ProtectingData();

Console.WriteLine("Pulsa una tecla para continuar...");
Console.Read();
