namespace Apuntes.Console.Presentacion.Console.Usuarios {
    public class MainConsole {
        private readonly UsuariosConsole usuariosConsole;

        public MainConsole(UsuariosConsole usuariosConsole) {
            this.usuariosConsole = usuariosConsole;
        }

        public void EntradaApp() {
            usuariosConsole.MostrarUsuarios();
        }
    }
}
