using System;
using System.IO;
using System.Linq;
using System.Text;

namespace ArchivosTexto.ClaseFile {
    internal class ReadFile {
        public ReadFile(string nombreArchivoText, string nombreArchivoTextAsync, string nombreArchivoBytes, string nombreArchivoAllLines) {
            var textoArchivoText = File.ReadAllText(nombreArchivoText);
            var textoArchivoTextAsync = File.ReadAllTextAsync(nombreArchivoTextAsync);
            var textoArchivoBytes = File.ReadAllBytes(nombreArchivoBytes);
            var textoArchivoAllLines = File.ReadAllLines(nombreArchivoAllLines);
            var textoArchivoLines = File.ReadLines(nombreArchivoAllLines).ToList();

            Console.WriteLine($"{nameof(textoArchivoText)}: {textoArchivoText}\n \n");
            Console.WriteLine($"{nameof(textoArchivoTextAsync)}: {textoArchivoTextAsync}\n \n");

            Console.WriteLine($"{nameof(textoArchivoBytes)}: {Encoding.UTF8.GetString(textoArchivoBytes)}\n \n");

            foreach (var texto in textoArchivoLines) {
                Console.WriteLine($"{nameof(textoArchivoAllLines)}: {texto}");
            }
            Console.WriteLine("\n \n");

            foreach (var texto in textoArchivoLines) {
                Console.WriteLine($"{nameof(textoArchivoLines)}: {texto}\n \n");
            }
        }
    }
}
