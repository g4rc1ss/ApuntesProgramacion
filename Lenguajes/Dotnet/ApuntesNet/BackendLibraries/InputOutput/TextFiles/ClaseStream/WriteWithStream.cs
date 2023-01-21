using System.IO;

namespace TextFiles.ClaseStream
{
    internal class WriteWithStream
    {
        public WriteWithStream(string nombreArchivo)
        {
            var textoEscribir = "Este es el texto que se esta \n escribiendo con la Clase Stream de .NET";

            using (var writeFile = new StreamWriter(nombreArchivo))
            {
                writeFile.Write(textoEscribir);
            }
        }
    }
}
