using System;
using System.Threading;

namespace ConexionesInternetCSharp {
    internal class Conexiones {
        private static void Main(string[] args) {
            // -------- Conexion para descargar archivos por REQUEST -------- \\
            new JSON.DescargarJSON().DescargarRequestJSON();

            // -------- Peticion de conexion tipo cliente -------- \\
            //new ConexionSocket.ConsultasSocket().EstablecerSocket();

            // -------- Conexion cliente-servidor -------- \\
            new Thread(() => new ConexionSocket.ClienteServidor.Servidor().Conectar()).Start();
            Thread.Sleep(new TimeSpan(0, 0, 5));
            new ConexionSocket.ClienteServidor.Cliente().Conectar();

            // -------- Enviar un Email -------- \\
            new Email.EnviarMailInyeccionDependenciasParaProtector();

            // -------- Conectar Active Directory -------- \\
            //new ActiveDirectory.AD();
        }
    }
}
