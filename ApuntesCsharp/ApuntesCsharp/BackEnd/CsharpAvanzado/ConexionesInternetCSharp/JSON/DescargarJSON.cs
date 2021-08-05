using System;
using System.IO;
using System.Net;

namespace ConexionesInternetCSharp.JSON {
    public class DescargarJSON {

        public void DescargarRequestJSON() {

            var host = Dns.GetHostEntry("google.es");
            var ip = host.AddressList[0].ToString();

            // Hago una consulta HTTP GET a una direccion o pagina web
            var request = (HttpWebRequest)WebRequest.Create(@"https://geoip-db.com/json/" + $"{ip}");
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
                Console.WriteLine($"Direccion ip: {leerJsonLocalizacion.IPv4} \n" +
                    $"Nombre del pais: {leerJsonLocalizacion.Country_name} \n" +
                    $"Nombre de la comunidad: {leerJsonLocalizacion.State} \n" +
                    $"Nombre de la ciudad: {leerJsonLocalizacion.City} \n" +
                    $"Latitud {leerJsonLocalizacion.Latitude} \n" +
                    $"Longitud {leerJsonLocalizacion.Longitude} \n" +
                    $"-----------------------------------------------"
                );
            }
        }
    }
}
