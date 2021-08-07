using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebAPI.Frontend.Api.Controllers {
    public class BaseApiController : ControllerBase {

        /// <summary>
        /// Creamos la respuesta para que nos devuelva los datos en formato JSON
        /// y asi poder leerlo en el Front
        /// </summary>
        /// <param name="respuesta"> Recibe un objeto, lo interpreta y crea una salida en formato JSON</param>
        /// <returns></returns>
        protected ContentResult CrearRespuesta(object respuesta) {
            var data = new Dictionary<string, object>();
            var resp = respuesta.GetType().GetProperties();
            foreach (var i in resp) {
                if (i.Name != null && i.GetValue(respuesta) != null) {
                    data.Add(i.Name, i.GetValue(respuesta));
                }
            }

            return Content(
                $"{JsonConvert.SerializeObject(data)}",
                "aplication/JSON",
                Encoding.UTF8
            );
        }
    }
}
