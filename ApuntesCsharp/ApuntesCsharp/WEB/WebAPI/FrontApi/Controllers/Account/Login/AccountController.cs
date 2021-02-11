using BackApi.Actions.Identity;
using FrontApi.Clases.Login;
using Garciss.Core.Common.Respuestas;
using InmobiliariaEguzkimendi.Core.BusinessManager.IdentityManager;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FrontApi.Controllers.pruebas {
    [ApiController]
    public class AccountController :BaseApiController {
        private readonly AccountAction accountAction;
        public AccountController(AccountAction accountAction) {
            this.accountAction = accountAction;
        }
        /// <summary>
        /// Creamos un hilo(tarea) para el proceso de Login, leemos del body el usuario y pass
        /// y despues se ejecuta el proceso de login
        /// </summary>
        /// <param name="credentials"></param>
        /// <returns>se retorna un objeto ContentResult, que es un objeto ya formado
        /// automaticamente por el metodo CrearRespuesta() que devuelve los datos en formato
        /// JSON</returns>
        [HttpPost]
        [Route("api/login")]
        public async Task<ContentResult> Login([FromBody] CredentialsLogin credentials) {
            var resp = await LoginAsync(credentials);
            return CrearRespuesta(resp);
        }
        private async Task<Respuesta> LoginAsync(CredentialsLogin credentials) {
            var resp = await accountAction.InicioSesion(credentials.Username, credentials.Password, false);
            return resp;
        }

        [HttpPost]
        [Route("api/logout")]
        public async Task<ContentResult> Logout() {
            var resp = await LogoutAsync();
            return CrearRespuesta(resp);
        }
        private async Task<Respuesta> LogoutAsync() {
            var resp = await accountAction.CerrarSesion();
            return resp;
        }

        [HttpPost]
        [Route("api/createAccount")]
        public async Task<ContentResult> CreateUser([FromBody] CreateAccountData createAccountData) {
            var resp = await CreateUserAsync(createAccountData);
            return CrearRespuesta(resp);
        }
        private async Task<Respuesta> CreateUserAsync(CreateAccountData createAccountData) {
            var resp = await accountAction.CrearCuentaUsuario(createAccountData);
            return resp;
        }
    }
}
