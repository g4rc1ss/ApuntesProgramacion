using System.IO;
using SqliteEfCore.Core;

namespace ParallelQueries.Console.Presentacion {
    internal class Program {
        private const string NOMBRE_BBDD = "BBDD_Local.db";
        private static void Main() {
            try {
                if (!File.Exists(NOMBRE_BBDD)) {
                    EjecutarQueries.CrearBaseDeDatos();
                }

                var allUsers = EjecutarQueries.CargarUsuarios();
                foreach (var user in allUsers) {
                    System.Console.WriteLine($"{user.Name} - {user.Edad}");
                }

                var allPueblos = EjecutarQueries.CargarPueblos();
                foreach (var pueblo in allPueblos) {
                    System.Console.WriteLine($"{pueblo.Nombre}");
                }
            } finally {
                File.Delete(NOMBRE_BBDD);
            }
        }
    }
}
