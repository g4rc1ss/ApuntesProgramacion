using System;
using System.IO;

namespace ArchivosTexto.ArchivosTexto.BinaryRead_Writer {
    public class LeerBinario {
        public void LeerArchivosBin() {
            // Apertura del archivo `ArchivoBinario.bin` en modo lectura:
            // Muestra la información tal cual está escrita en el archivo binario:
            using (var fs = new FileStream("ArchivoBinario.bin", FileMode.Open, FileAccess.Read)) {
                Console.Write(Environment.NewLine);
                // Lectura y conversión de los datos binarios en el tipo de 
                // correspondiente:

                // Posiciona el cursor desde se iniciara la lectura del 
                // archivo `ArchivoBinario`:
                fs.Position = 0;
                using (var br = new BinaryReader(fs)) {
                    Console.WriteLine(br.ReadDecimal());
                    Console.WriteLine(br.ReadString());
                    Console.WriteLine(br.ReadString());
                    Console.WriteLine(br.ReadChar());
                }
            }
        }
    }
}
