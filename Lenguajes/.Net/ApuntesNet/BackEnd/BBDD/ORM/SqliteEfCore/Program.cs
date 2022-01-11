using SqliteEfCore.Core;


EjecutarQueries.CrearBaseDeDatos();

await EjecutarQueries.InsertDataAsync();
await EjecutarQueries.UpdateData();
await EjecutarQueries.DeleteData();
var allUsers = await EjecutarQueries.SelectData();

foreach (var user in allUsers)
{
    System.Console.WriteLine($"Nombre {user.Name} - Edad {user.Edad} - Pueblo {user.Pueblo.Nombre}");
}
