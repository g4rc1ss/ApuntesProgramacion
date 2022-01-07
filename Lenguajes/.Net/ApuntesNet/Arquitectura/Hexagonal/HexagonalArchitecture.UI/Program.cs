using HexagonalArchitecture.Application;
using HexagonalArchitecture.DB;

var dependenciaDb = DependencyDbFactory.GetSimulacionBaseDatos();
var usuarios = DependencyApplicationFactory.GetUserManager(dependenciaDb);

var listaUsuarios = await usuarios.GetUsersList();

foreach (var item in listaUsuarios)
{
    Console.WriteLine($"{item.Name}------------{item.Email}");
}
