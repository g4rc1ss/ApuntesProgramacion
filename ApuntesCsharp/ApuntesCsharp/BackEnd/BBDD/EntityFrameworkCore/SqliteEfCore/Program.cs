using System.IO;
using SqliteEfCore.Actions.MainWindow;

namespace ParallelQueries.Console.Presentacion {
    internal class Program {
        private static void Main() {
            if (!File.Exists("BBDD_Local.db")) {
                CapaBackConFront.CrearBaseDeDatos();
            }

            var allData = CapaBackConFront.CargaDeBaseDeDatos();
            foreach (var data in allData) {
                System.Console.WriteLine($"{data.GetType().GetProperty("Name")}");
            }
        }
    }
}
