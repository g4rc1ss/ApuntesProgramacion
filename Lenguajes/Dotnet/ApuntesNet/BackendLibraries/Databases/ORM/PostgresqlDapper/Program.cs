using Microsoft.Extensions.DependencyInjection;


using PostgresqlDapper;
using PostgresqlDapper.Repository;
using PostgresqlDapper.Repository.SelectExtensionMethods;

var serviceProvider = Helper.CreateDependencyInjection();

var createTable = serviceProvider.GetRequiredService<CreateTable>();
await createTable.CreateTableAsync();

var insertData = serviceProvider.GetRequiredService<InsertData>();
await insertData.InsertDataQueryAsync();

var updateData = serviceProvider.GetRequiredService<UpdateData>();
//await updateData.UpdateDataQueryAsync();

var selectData = serviceProvider.GetRequiredService<SelectData>();
await selectData.SelectDataQueryAsync();
await selectData.SelectDataSingleAsync();
await selectData.SelectDataMultipleQueryAsync();
await selectData.SelectDataMappingComplexObjectsAsync();


var deleteData = serviceProvider.GetRequiredService<DeleteData>();
await deleteData.DeleteDataQueryAsync();


Console.WriteLine("\n Pulsa una tecla para finalizar");
Console.ReadKey();

