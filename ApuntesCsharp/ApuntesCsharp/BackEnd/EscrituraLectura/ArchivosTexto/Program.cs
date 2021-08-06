using ArchivosTexto.ArchivosTexto.BinaryRead_Writer;
using ArchivosTexto.ArchivosTexto.StreamRead_Writer;

namespace ArchivosTexto {
    internal class Program {
        private static void Main(string[] args) {
            // Leemos y escribimos archivos binarios, ".bin"
            new EscribirBinario().EscribirArchivosBin();
            new LeerBinario().LeerArchivosBin();
            new ReadAndWriteBinaryFile();

            // Leemos y escribimos archivos con la libreria Stream
            new ReadAndWriteWithStream();
        }
    }
}
