using System;
using System.Threading.Tasks;
using JsonFiles.JSON;
using JsonFiles.Read;
using JsonFiles.Write;

namespace JsonFiles
{
    internal class Program
    {
        private static async Task Main()
        {
            // Creamos un archivo JSON para indicar la ruta
            var crearJSON = new ClaseParaJSON()
            {
                Ruta = "archivo.txt"
            };

            // Usamos JSON
            await JsonWriteSerialization.UsingJSONAsync(crearJSON);
            Console.WriteLine("\n-------------------------------------------------------------\n");
            await JsonReadDeserialize.UsingJSONAsync();
        }
    }
}
