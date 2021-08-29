using System;
using System.IO;
using JsonFiles.JSON;
using Newtonsoft.Json;

namespace JsonFiles.Write {
    public class JsonWriteSerialization {
        public static void UsingJSON(ClaseParaJSON json) {

            var jsonEscritura = JsonConvert.SerializeObject(json);
            Console.WriteLine("JSON serializado:");
            Console.WriteLine(jsonEscritura);
            File.WriteAllText("ruta.json", jsonEscritura);
        }
    }
}
