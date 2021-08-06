using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace UseApiWeb.JSON {
    public class DescargarJSON {

        public void DescargarRequestJSON() {

            var host = Dns.GetHostEntry("google.es");
            var ip = host.AddressList[0].ToString();

            // Hago una consulta HTTP GET a una direccion o pagina web
            var request = (HttpWebRequest)WebRequest.Create(@"https://ipinfo.io/" + ip + "/json");
            // Descargo la pagina web (un JSON en este caso)
            using (var response = (HttpWebResponse)request.GetResponse())
            // Obtengo un stream para escribir la informacion descargada
            using (var stream = response.GetResponseStream())
            // Cargo el Stream para leerlo
            using (var reader = new StreamReader(stream)) {
                // leemos el JSON
                var leerConsultaWebJson = reader.ReadToEnd();
                // Convertimos los datos del JSON en un objeto de clase <leerJSON>
                var leerJsonLocalizacion = JsonConvert.DeserializeObject<LeerJSON>(leerConsultaWebJson);
                Console.WriteLine($"Direccion ip: {leerJsonLocalizacion.Ip} \n" +
                    $"Nombre del pais: {leerJsonLocalizacion.Country} \n" +
                    $"Nombre de la ciudad: {leerJsonLocalizacion.City} \n" +
                    $"Latitud y Longitud {leerJsonLocalizacion.Loc} \n" +
                    $"Archivo Readme: {leerJsonLocalizacion.Readme} \n" +
                    $"-----------------------------------------------"
                );
            }
        }
    }
}
