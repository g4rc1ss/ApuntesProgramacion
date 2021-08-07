using System.Threading.Tasks;
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
        public async Task<ContentResult> CifrarAsync([FromBody] Texto text) {
            _ = new Texto {
                Text = await cipherAction.CifrarTexto(text.Text)
            };
            return CrearRespuesta(text);
        }
    }

    public class Texto {
        public string Text { get; set; }
    }
}
