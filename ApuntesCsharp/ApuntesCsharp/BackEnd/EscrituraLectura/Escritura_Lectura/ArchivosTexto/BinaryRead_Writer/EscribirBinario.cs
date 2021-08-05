using System;
using System.IO;

namespace Escritura_Lectura.ArchivosTexto.BinaryRead_Writer {
    public class EscribirBinario {
        public void EscribirArchivosBin() {
            // Crea objeto `FileStream` para referenciar un archivo binario -ArchivoBinario.bin-:
            // Escritura sobre el archivo binario `ArchivoBinario.bin` usando un 
            // objeto de la clase `BinaryWriter`:
            using (var fs = new FileStream("ArchivoBinario.bin", FileMode.Create, FileAccess.Write))
            using (var bw = new BinaryWriter(fs)) {
                // Escritura de datos de naturaleza primitiva:
                bw.Write(4596.35M);
                bw.Write("jhuihjnui");
                bw.Write("hkjhuih - xCSw");
                bw.Write('!');
            }
            Console.WriteLine("Los datos han sido escritos en el archivo `ArchivoBinario.bin`.");
        }
    }
}
