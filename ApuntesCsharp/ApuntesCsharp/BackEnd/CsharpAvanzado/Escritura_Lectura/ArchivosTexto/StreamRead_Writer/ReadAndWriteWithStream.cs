using System.IO;

namespace Escritura_Lectura.ArchivosTexto.StreamRead_Writer {
    public class ReadAndWriteWithStream {
        public ReadAndWriteWithStream() {
            var fuente = "./archivo";
            var destino = "./destino";
            using (File.Create(fuente)) {
                if (File.Exists(fuente)) ;
            }
            File.WriteAllText(fuente, "fdsjfkhrjgflhndsbafbgrheikabhfarigfbsrghfaslbhfreai \n bfhwbgf rhjsbfgdhsflbglavgfb lcvjavf ljubfa asgfjveasfb esfj");
            using (File.Create(destino)) { }

            using (var readFile = new StreamReader(fuente)) {
                using (var writeFile = new StreamWriter(destino)) {
                    writeFile.Write(readFile.ReadToEnd());
                }
            }
        }
    }
}
