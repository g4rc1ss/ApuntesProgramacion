using System;
using System.IO;

namespace Escritura_Lectura.JSON {
    public class UsarJSON {
        public void UsingJSON() {
            // Creamos un archivo JSON para indicar la ruta
            var crearJSON = new ClaseParaJSON() {
                Ruta = "archivo.txt"
            };

            var jsonEscritura = JsonConvert.SerializeObject(crearJSON);
            File.WriteAllText(Directory.GetCurrentDirectory() + "/ruta.json", jsonEscritura);

            //Leemos el archivo JSON para indicar la ruta de lectura del fichero
            using (var jsonLectura = File.OpenText(Directory.GetCurrentDirectory() + "/ruta.json")) {
                var json = jsonLectura.ReadToEnd();
                var localizacion = JsonConvert.DeserializeObject<ClaseParaJSON>(json);
                Console.WriteLine(localizacion.Ruta);
            }
        }
    }
}
