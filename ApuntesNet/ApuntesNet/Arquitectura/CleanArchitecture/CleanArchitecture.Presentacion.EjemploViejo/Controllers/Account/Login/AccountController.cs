using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Backend.Business.Actions.Account.Interfaces;
using WebAPI.Backend.Business.BusinessManager.IdentityManager;
using WebAPI.Frontend.Api.Clases.Login;

namespace WebAPI.Frontend.Api.Controllers.Account.Login {
    [ApiController]
    public class AccountController : Controller {
        private readonly IAccountAction accountAction;
        public AccountController(IAccountAction accountAction) {
            this.accountAction = accountAction;
        }
        /// <summary>
        /// Creamos un hilo(tarea) para el proceso de Login, leemos del body el usuario y pass
        /// y despues se ejecuta el proceso de login
        /// </summary>
        /// <param name="credentials"></param>
        /// <returns>se retorna un objeto ContentResult, que es un objeto ya formado
        /// automaticamente por el metodo ) ue devuelve los datos en formato
        /// JSON</returns>
        [HttpPost]
        [Route("api/login")]
        public async Task<bool> Login([FromBody] CredentialsLogin credentials) {
            var resp = await LoginAsync(credentials);
            return resp;
        }
        private async Task<bool> LoginAsync(CredentialsLogin credentials) {
            var resp = await accountAction.InicioSesionAsync(credentials.Username, credentials.Password, false);
            return resp;
        }

        [HttpPost]
        [Route("api/logout")]
        public async Task<bool> Logout() {
            var resp = await LogoutAsync();
            return resp;
        }
        private async Task<bool> LogoutAsync() {
            var resp = await accountAction.CerrarSesionAsync();
            return resp;
        }

        [HttpPost]
        [Route("api/createAccount")]
        public async Task<bool> CreateUser([FromBody] CreateAccountData createAccountData) {
            var resp = await CreateUserAsync(createAccountData);
            return resp;
        }
        private async Task<bool> CreateUserAsync(CreateAccountData createAccountData) {
            var resp = await accountAction.CrearCuentaUsuarioAsync(createAccountData);
            return resp;
        }
    }
}
