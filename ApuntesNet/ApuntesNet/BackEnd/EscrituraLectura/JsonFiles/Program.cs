using System;
using JsonFiles.JSON;
using JsonFiles.Read;
using JsonFiles.Write;

namespace JsonFiles
{
    internal class Program
    {
        private static void Main()
        {
            // Creamos un archivo JSON para indicar la ruta
            var crearJSON = new ClaseParaJSON()
            {
                Ruta = "archivo.txt"
            };

            // Usamos JSON
            JsonWriteSerialization.UsingJSON(crearJSON);
            Console.WriteLine("\n-------------------------------------------------------------\n");
            JsonReadDeserialize.UsingJSON();
        }
    }
}
