using System;
using System.Net;
using System.Net.Sockets;

namespace ConexionesSocket.ConexionSocket {
    public class ConsultasSocket {
        public static void EstablecerSocket() {
            Socket socket = null;
            var port = 22;

            try {
                var host = Dns.GetHostEntry("google.es");
                var ip = host.AddressList[1].ToString();

                socket = new Socket(
                   AddressFamily.InterNetwork,
                   SocketType.Stream,
                   ProtocolType.Tcp
                );
                socket.Connect(new IPEndPoint(IPAddress.Parse(ip), port));
                socket.Close();
                Console.WriteLine($"[+] puerto {port} cerrado");
            } catch (Exception) {
                socket.Close();
                Console.WriteLine($"[-] puerto {port} cerrado");
            }
        }
    }
}
