﻿using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using JsonFiles.JSON;

namespace JsonFiles.Read
{
    public class JsonReadDeserialize
    {
        public static async Task UsingJSONAsync()
        {
            using var jsonStream = File.Open("ruta.json", FileMode.Open, FileAccess.Read);
            var localizacion = await JsonSerializer.DeserializeAsync<ClaseParaJSON>(jsonStream);

            Console.WriteLine("JSON Deserializado:");
            Console.WriteLine(localizacion.Ruta);
        }
    }
}