using System.IO;

namespace Apuntes.Console.Presentacion {
    internal class Program {
        private static void Main(string[] args) {
            if (!File.Exists("BBDD_Local.db"))
                new BackLocal.Core.Actions.MainWindow.CapaBackConFront().CrearBaseDeDatos();
            var users = new BackLocal.Core.Actions.MainWindow.CapaBackConFront().CargaDeBaseDeDatos();
            foreach (var user in users)
                System.Console.WriteLine($"{user.Name} - {user.Edad}");
        }
    }
}
