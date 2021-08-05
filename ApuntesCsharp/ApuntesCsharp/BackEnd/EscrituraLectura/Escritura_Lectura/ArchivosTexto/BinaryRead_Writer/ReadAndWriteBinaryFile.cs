using System.IO;

namespace Escritura_Lectura.ArchivosTexto.BinaryRead_Writer {
    public class ReadAndWriteBinaryFile {
        public ReadAndWriteBinaryFile() {
            var fuente = "./archivo";
            var destino = "./destino";
            using (File.Create(fuente)) {
            }
            File.WriteAllText(fuente, "fdsjfkhrjgflhndsbafbgrheikabhfarigfbsrghfaslbhfreai \n bfhwbgf rhjsbfgdhsflbglavgfb lcvjavf ljubfa asgfjveasfb esfj");
            using (File.Create(destino)) { }

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
