using System;
using System.Net;               //   Paso 1
using System.Net.Sockets;       //   Paso 1

namespace ConexionesInternetCSharp.ConexionSocket.ClienteServidor {
    public class Servidor {

        public void Conectar() {
            using (var miPrimerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)) {
                // paso 2 - creamos el socket
                var miDireccion = new IPEndPoint(IPAddress.Parse("0.0.0.0"), 1234);
                //paso 3 -IPAddress.Any significa que va a escuchar al cliente en toda la red 
                try {
                    // paso 4
                    miPrimerSocket.Bind(miDireccion); // Asociamos el socket a miDireccion
                    miPrimerSocket.Listen(1); // Lo ponemos a escucha

                    Console.WriteLine("Escuchando...");
                    var escuchar = miPrimerSocket.Accept();
                    //creamos el nuevo socket, para comenzar a trabajar con él
                    //La aplicación queda en reposo hasta que el socket se conecte a el cliente
                    //Una vez conectado, la aplicación sigue su camino  
                    Console.WriteLine("[Servidor]: Conectado con exito");

                    /*Aca ponemos todo lo que queramos hacer con el socket, osea antes de 
                    cerrarlo je*/
                    miPrimerSocket.Close(); //Luego lo cerramos

                } catch (Exception error) {
                    Console.WriteLine("Error: {0}", error.ToString());
                }
            }
        }
    }
}
