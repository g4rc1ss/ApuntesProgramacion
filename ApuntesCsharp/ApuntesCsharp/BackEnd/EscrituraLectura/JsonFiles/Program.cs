using JsonFiles.JSON;
using JsonFiles.Read;
using JsonFiles.Write;
using System;

namespace JsonFiles {
    internal class Program {
        private static void Main(string[] args) {
            // Creamos un archivo JSON para indicar la ruta
            var crearJSON = new ClaseParaJSON() {
                Ruta = "archivo.txt"
            };

            // Usamos JSON
            new JsonWriteSerialization().UsingJSON(crearJSON);
            Console.WriteLine("\n-------------------------------------------------------------\n");
            new JsonReadDeserialize().UsingJSON();
        }
    }
}
