using JsonFiles.JSON;
using Newtonsoft.Json;
using System;
using System.IO;

namespace JsonFiles.Write {
    public class JsonWriteSerialization {
        public void UsingJSON(ClaseParaJSON json) {

            var jsonEscritura = JsonConvert.SerializeObject(json);
            Console.WriteLine("JSON serializado:");
            Console.WriteLine(jsonEscritura);
            File.WriteAllText("ruta.json", jsonEscritura);
        }
    }
}
