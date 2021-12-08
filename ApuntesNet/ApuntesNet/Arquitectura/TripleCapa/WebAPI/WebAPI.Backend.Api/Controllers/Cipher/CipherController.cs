using Microsoft.AspNetCore.Mvc;
using WebAPI.Backend.Business.Actions.Cipher.Interfaces;

namespace WebAPI.Frontend.Api.Controllers.Cipher {
    [ApiController]
    [Route("api/[controller]")]
    public class CipherController : Controller {
        private readonly ICipherAction cipherAction;

        public CipherController(ICipherAction cipherAction) {
            this.cipherAction = cipherAction;
        }

        [ResponseCache(Duration = 4320)]
        [HttpGet("cifrartext/{texto}")]
        public Texto Cifrar(string texto) {
            var textoCifrado = new Texto {
                Text = cipherAction.CifrarTexto(texto)
            };
            return textoCifrado;
        }
    }

    public class Texto {
        public string Text { get; set; }
    }
}
