using System;
using System.Net;
using System.Net.Sockets;

namespace ConexionesSocket.ConexionSocket.ClienteServidor {
    public class Cliente {

        public static void Conectar() {
            using (var miPrimerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)) {
                // paso 2 - creamos el socket
                var miDireccion = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);
                //paso 3 - Acá debemos poner la Ip del servidor, y el puerto de escucha del servidor
                //Yo puse esa porque corrí las dos aplicaciones en la misma pc
                try {
                    miPrimerSocket.Connect(miDireccion); // Conectamos                
                    Console.WriteLine("[Cliente]: Conectado con exito");
                    miPrimerSocket.Close();
                } catch (Exception error) {
                    Console.WriteLine("[Error]: {0}", error.ToString());
                }
            }
        }
    }
}
