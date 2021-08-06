using System.IO;

namespace ArchivosTexto.ArchivosTexto.BinaryRead_Writer {
    public class ReadAndWriteBinaryFile {
        public ReadAndWriteBinaryFile() {
            var fuente = "./archivo";
            var destino = "./destino";
            
            using (File.Create(fuente)) { }
            using (File.Create(destino)) { }

            File.WriteAllText(fuente, "fdsjfkhrjgflhndsbafbgrheikabhfarigfbsrghfaslbhfreai \n bfhwbgf rhjsbfgdhsflbglavgfb lcvjavf ljubfa asgfjveasfb esfj");

            using (var readBinaryFile = new BinaryReader(File.OpenRead(fuente))) {
                using (var writeBinaryFile = new BinaryWriter(File.OpenWrite(destino))) {
                    for (byte data; readBinaryFile.PeekChar() != -1;) {
                        data = readBinaryFile.ReadByte();
                        writeBinaryFile.Write(data);
                    }
                }
            }
        }
    }
}
