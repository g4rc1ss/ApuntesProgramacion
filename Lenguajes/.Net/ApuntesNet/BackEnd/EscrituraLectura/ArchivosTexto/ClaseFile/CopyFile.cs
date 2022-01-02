using System.IO;

namespace ArchivosTexto.ClaseFile
{
    internal class CopyFile
    {
        public CopyFile(string nombreArchivoOrigen, string nombreArchivoDestino)
        {
            File.Copy(nombreArchivoOrigen, nombreArchivoDestino);
        }
    }
}
