using BackApi;
using Microsoft.AspNetCore.Mvc;

namespace FrontApi.Controllers {
    [ApiController]
    public class ValuesController :BaseApiController {

        [ResponseCache(Duration = 4320)]
        [HttpGet]
        [Route("api/cifrarText")]
        public ContentResult Cifrar([FromBody] Texto text) {
            return CrearRespuesta(new Prueba().CifrarText(text.Text));
        }
    }

    public class Texto {
        public string Text { get; set; }
    }
}
