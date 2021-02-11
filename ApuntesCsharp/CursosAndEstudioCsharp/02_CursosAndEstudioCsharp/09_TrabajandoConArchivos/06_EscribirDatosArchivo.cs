using System.IO;
using System.Text;

namespace CursosAndEstudioCsharp._09_TrabajandoConArchivos
{
    internal class _06_EscribirDatosArchivo
    {
        public _06_EscribirDatosArchivo()
        {
            var fs = new FileStream("miArchivo.txt", FileMode.Append);

            var cadena = " Esto es una cadena añadida";

            fs.Write(ASCIIEncoding.ASCII.GetBytes(cadena), 0, cadena.Length);
            fs.Close();
        }
    }
}
