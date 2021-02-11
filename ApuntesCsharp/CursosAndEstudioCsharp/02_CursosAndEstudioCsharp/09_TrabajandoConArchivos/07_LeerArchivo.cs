using System;
using System.IO;
using System.Text;

namespace CursosAndEstudioCsharp._09_TrabajandoConArchivos
{
    internal class _07_LeerArchivo
    {
        public _07_LeerArchivo()
        {
            var fsEscribir = new FileStream("miArchivo.txt", FileMode.Create);

            var cadena = " Esto es una cadena de ejemplo";

            fsEscribir.Write(ASCIIEncoding.ASCII.GetBytes(cadena), 0, cadena.Length);
            fsEscribir.Close();


            var infoArchivo = new byte[100];

            var fs = new FileStream("miArchivo.txt", FileMode.Open);
            fs.Read(infoArchivo, 0, (int)fs.Length);

            Console.WriteLine(ASCIIEncoding.ASCII.GetString(infoArchivo));
            Console.ReadKey();

            fs.Close();
        }
    }
}
