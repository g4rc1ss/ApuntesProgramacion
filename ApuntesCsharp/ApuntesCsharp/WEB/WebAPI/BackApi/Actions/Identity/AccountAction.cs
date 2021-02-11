using BackApi.BusinessManager.IdentityManager;
using Garciss.Core.Common.Respuestas;
using InmobiliariaEguzkimendi.Core.BusinessManager.IdentityManager;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace BackApi.Actions.Identity {
    public class AccountAction {
        private readonly ILogger<AccountAction> logger;
        private readonly ApplicationUserManager applicationUserManager;

        public AccountAction(ILogger<AccountAction> logger, ApplicationUserManager applicationUserManager) {
            this.logger = logger;
            this.applicationUserManager = applicationUserManager;
        }

        public Task<Respuesta> InicioSesion(string username, string password, bool rememberMe) {
            return Task.Run(() => {
                try {
                    return applicationUserManager.Login(username, password, rememberMe);
                } catch (Exception ex) {
                    return new Respuesta(ex, nameof(InicioSesion), logger);
                }
            });
        }

        public Task<Respuesta> CerrarSesion() {
            return Task.Run(() => {
                try {
                    return applicationUserManager.Logout();
                } catch (Exception ex) {
                    return new Respuesta(ex, nameof(CerrarSesion), logger);
                }
            });
        }

        public Task<Respuesta> CrearCuentaUsuario(CreateAccountData createAccountData) {
            return Task.Run(() => {
                try {
                    return applicationUserManager.CreateUserAccount(createAccountData);
                } catch (Exception ex) {
                    return new Respuesta(ex, nameof(CrearCuentaUsuario), logger);
                }
            });
        }
    }
}
