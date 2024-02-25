using System.Net;
using System.Net.Sockets;

namespace Sockets.ConexionSocket;

public class ConsultarPuertosAbiertos
{
    public static void EscanerPuertos()
    {
        var port = 80;

        try
        {
            using var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            var host = Dns.GetHostEntry("google.es");
            var ip = host.AddressList[0]?.ToString();
            if (ip == null)
            {
                return;
            }

            socket.Connect(new IPEndPoint(IPAddress.Parse(ip), port));
            Console.WriteLine($"[+] puerto {port} abierto");
        }
        catch (Exception)
        {
            Console.WriteLine($"[-] puerto {port} cerrado");
        }
    }
}
