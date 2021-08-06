using System.IO;

namespace ParallelQueries.Console.Presentacion {
    internal class Program {
        private static void Main() {
            if (!File.Exists("BBDD_Local.db")) {
                BackLocal.Core.Actions.MainWindow.CapaBackConFront.CrearBaseDeDatos();
            }

            var allData = BackLocal.Core.Actions.MainWindow.CapaBackConFront.CargaDeBaseDeDatos();
            foreach (var data in allData) {
                System.Console.WriteLine($"{data.GetType().GetProperty("Name")}");
            }
        }
    }
}
