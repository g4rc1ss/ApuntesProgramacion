using System;

namespace ConexionesSocket {
    internal class Program {
        private static void Main() {
            // -------- Peticion de conexion tipo cliente -------- \\
            //new ConexionSocket.ConsultasSocket().EstablecerSocket();

            // -------- Conexion cliente-servidor -------- \\
            new Thread(() => new ConexionSocket.ClienteServidor.Servidor().Conectar()).Start();
            Thread.Sleep(new TimeSpan(0, 0, 5));
            new ConexionSocket.ClienteServidor.Cliente().Conectar();
        }
    }
}
