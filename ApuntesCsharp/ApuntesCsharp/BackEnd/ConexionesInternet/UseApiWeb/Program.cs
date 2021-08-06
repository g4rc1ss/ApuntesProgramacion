using System;

namespace UseApiWeb {
    internal class Program {
        private static void Main() {
            // -------- Conexion para descargar archivos por REQUEST -------- \\
            new JSON.DescargarJSON().DescargarRequestJSON();
        }
    }
}
