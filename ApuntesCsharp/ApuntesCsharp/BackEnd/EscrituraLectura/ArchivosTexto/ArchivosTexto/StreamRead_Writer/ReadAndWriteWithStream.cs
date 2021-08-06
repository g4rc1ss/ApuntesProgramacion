using System.IO;

namespace ArchivosTexto.ArchivosTexto.StreamRead_Writer {
    public class ReadAndWriteWithStream {
        public ReadAndWriteWithStream() {
            var fuente = "./archivo";
            var destino = "./destino";

            using (File.Create(fuente)) { }
            using (File.Create(destino)) { }
            
            File.WriteAllText(fuente, "fdsjfkhrjgflhndsbafbgrheikabhfarigfbsrghfaslbhfreai \n bfhwbgf rhjsbfgdhsflbglavgfb lcvjavf ljubfa asgfjveasfb esfj");

            using (var readFile = new StreamReader(fuente)) {
                using (var writeFile = new StreamWriter(destino)) {
                    writeFile.Write(readFile.ReadToEnd());
                }
            }
        }
    }
}
