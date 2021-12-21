using System.IO;

namespace ArchivosTexto.ClaseBinary
{
    public class CopyBinaryFile
    {
        public CopyBinaryFile(string nombreArchivoFuente, string nombreArchivoDestino)
        {
            using (var readBinaryFile = new BinaryReader(File.OpenRead(nombreArchivoFuente)))
            using (var writeBinaryFile = new BinaryWriter(File.OpenWrite(nombreArchivoDestino)))
            {
                for (byte data; readBinaryFile.PeekChar() != -1;)
                {
                    data = readBinaryFile.ReadByte();
                    writeBinaryFile.Write(data);
                }
            }
        }
    }
}
