using Microsoft.AspNetCore.Mvc;
using WebAPI.Backend.Business.Actions.Cipher.Interfaces;

namespace WebAPI.Frontend.Api.Controllers.Cipher {
    [ApiController]
    public class CipherController : BaseApiController {
        private readonly ICipherAction cipherAction;

        public CipherController(ICipherAction cipherAction) {
            this.cipherAction = cipherAction;
        }

        [ResponseCache(Duration = 4320)]
        [HttpGet]
        [Route("api/cifrarText")]
        public IActionResult CifrarAsync([FromBody] Texto text) {
            var textoCifrado = new Texto {
                Text = cipherAction.CifrarTexto(text.Text)
            };
            return CrearRespuesta(textoCifrado);
        }
    }

    public class Texto {
        public string Text { get; set; }
    }
}
