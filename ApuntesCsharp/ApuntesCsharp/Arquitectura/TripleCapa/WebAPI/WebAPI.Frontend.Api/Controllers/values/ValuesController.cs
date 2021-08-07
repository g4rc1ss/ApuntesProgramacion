using Microsoft.AspNetCore.Mvc;
using WebAPI.Backend.Business;

namespace WebAPI.Frontend.Api.Controllers.values {
    [ApiController]
    public class ValuesController : BaseApiController {

        [ResponseCache(Duration = 4320)]
        [HttpGet]
        [Route("api/cifrarText")]
        public ContentResult Cifrar([FromBody] Texto text) {
            _ = new Texto {
                Text = Prueba.CifrarText(text.Text)
            };
            return CrearRespuesta(text);
        }
    }

    public class Texto {
        public string Text { get; set; }
    }
}
