using System;
using System.Threading;

namespace ConexionesSocket
{
    internal class Program
    {
        private static void Main()
        {
            // -------- Peticion de conexion tipo cliente -------- \\
            ConexionSocket.ConsultarPuertosAbiertos.EscanerPuertos();

            // -------- Conexion cliente-servidor -------- \\
            new Thread(() => ConexionSocket.ClienteServidor.Servidor.Conectar()).Start();
            Thread.Sleep(new TimeSpan(0, 0, 5));
            ConexionSocket.ClienteServidor.Cliente.Conectar();
        }
    }
}
