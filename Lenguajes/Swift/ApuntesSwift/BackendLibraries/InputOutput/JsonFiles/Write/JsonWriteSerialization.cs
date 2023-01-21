using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using JsonFiles.JSON;

namespace JsonFiles.Write
{
    public class JsonWriteSerialization
    {
        public static async Task UsingJSONAsync(ClaseParaJSON json)
        {
            using var jsonStream = File.OpenWrite("ruta.json");
            await JsonSerializer.SerializeAsync(jsonStream, json);
        }
    }
}
