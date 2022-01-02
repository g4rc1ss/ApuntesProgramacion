using SqliteEfCore.Core;

namespace SqliteEfCore
{
    internal class Program
    {
        private static void Main()
        {
            EjecutarQueries.CrearBaseDeDatos();

            EjecutarQueries.InsertData();
            EjecutarQueries.UpdateData();
            EjecutarQueries.DeleteData();
            var allUsers = EjecutarQueries.SelectData();
            foreach (var user in allUsers)
            {
                System.Console.WriteLine($"Nombre {user.Name} - Edad {user.Edad} - Pueblo {user.Pueblo.Nombre}");
            }
        }
    }
}
