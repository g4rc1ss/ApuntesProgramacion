using System;
using System.IO;
using System.Text;

namespace CursosAndEstudioCsharp._09_TrabajandoConArchivos
{
    internal class _04_EscribirDatosStream
    {
        public _04_EscribirDatosStream()
        {
            var ms = new MemoryStream(150);
            var capacidad = ms.Capacity;
            var longitud = ms.Length;
            var posicion = ms.Position;

            var miBuffer = new byte[50];
            ms.Write(miBuffer, 0, 15);
            ms.Close();


            //Ejemplo
            var memStream = new MemoryStream(50);
            var miInformacion = string.Empty;

            var capacidad2 = memStream.Capacity;
            var longitud2 = memStream.Length;
            var posicion2 = memStream.Position;

            var buffer = new byte[50];

            // El usuario da los datos
            Console.WriteLine("introduce la información");
            miInformacion = Console.ReadLine();

            memStream.Write(ASCIIEncoding.ASCII.GetBytes(miInformacion), 0, miInformacion.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            memStream.Read(buffer, 0, 5); // desde donde nos encontramos, 5 caracteres 

            Console.WriteLine(ASCIIEncoding.ASCII.GetString(buffer));

            memStream.Close();
        }
    }
}
