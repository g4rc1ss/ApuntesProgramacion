using System;
using System.IO;
using JsonFiles.JSON;
using Newtonsoft.Json;

namespace JsonFiles.Read {
    public class JsonReadDeserialize {
        public static void UsingJSON() {

            //Leemos el archivo JSON para indicar la ruta de lectura del fichero
            using (var jsonLectura = File.OpenText("ruta.json")) {
                var json = jsonLectura.ReadToEnd();
                var localizacion = JsonConvert.DeserializeObject<ClaseParaJSON>(json);
                Console.WriteLine("JSON Deserializado:");
                Console.WriteLine(localizacion.Ruta);
            }
        }
    }
}
