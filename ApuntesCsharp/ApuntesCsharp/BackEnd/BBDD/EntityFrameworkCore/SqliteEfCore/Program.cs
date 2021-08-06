using System.IO;
using SqliteEfCore.Core;

namespace ParallelQueries.Console.Presentacion {
    internal class Program {
        private static void Main() {
            if (!File.Exists("BBDD_Local.db")) {
                EjecutarQueries.CrearBaseDeDatos();
            }

            var allData = EjecutarQueries.CargaDeBaseDeDatos();
            foreach (var data in allData) {
                System.Console.WriteLine($"{data.GetType().GetProperty("Name")}");
            }
        }
    }
}
