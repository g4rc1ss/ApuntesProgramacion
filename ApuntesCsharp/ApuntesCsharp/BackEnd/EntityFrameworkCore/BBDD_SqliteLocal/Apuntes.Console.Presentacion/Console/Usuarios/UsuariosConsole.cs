using Apuntes.BackLocal.Core.Actions;

namespace Apuntes.Console.Presentacion.Console.Usuarios {
    public class UsuariosConsole {
        private readonly UserAction userAction;

        public UsuariosConsole(UserAction userAction) {
            this.userAction = userAction;
        }

        public async void MostrarUsuarios() {
            System.Console.WriteLine("Teclear la edad");
            var edad = int.Parse(System.Console.ReadLine());

            var users = await userAction.GetAllUsers();
            foreach (var user in users.Datos) {
                System.Console.WriteLine($"Usuario: {user.Nombre} - Edad: {user.Edad} - Fecha: {user.FechaHoy}");
            }
        }
    }
}
