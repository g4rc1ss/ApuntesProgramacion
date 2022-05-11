using Microsoft.Extensions.DependencyInjection;
using SqlServerEfCore;
using SqlServerEfCore.Repository;

var serviceProvider = Helper.CreateDependencyInjection();

var insertService = serviceProvider.GetRequiredService<InsertData>();
await insertService.InsertDataAsync();

var updateService = serviceProvider.GetRequiredService<UpdateData>();
await updateService.UpdateDataAsync();

var selectService = serviceProvider.GetRequiredService<SelectData>();
var allUsers = await selectService.SelectDataAsync();


var deleteService = serviceProvider.GetRequiredService<DeleteData>();
await deleteService.DeleteDataAsync();


foreach (var user in allUsers)
{
    Console.WriteLine($"Nombre {user.Nombre} - Edad {user.Edad} - Pueblo {user.PuebloIdNavigation.Nombre}");
}

Console.WriteLine("\n Pulsa una tecla para finalizar");
Console.ReadKey();
