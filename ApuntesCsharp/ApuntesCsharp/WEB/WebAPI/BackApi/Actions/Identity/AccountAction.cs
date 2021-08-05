using BackApi.BusinessManager.IdentityManager;
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

        public Task<bool> InicioSesion(string username, string password, bool rememberMe) {
            return Task.Run(() => {
                try {
                    return applicationUserManager.Login(username, password, rememberMe);
                } catch (Exception) {
                    logger.LogInformation(nameof(InicioSesion));
                    return false;
                }
            });
        }

        public Task<bool> CerrarSesion() {
            return Task.Run(() => {
                try {
                    return applicationUserManager.Logout();
                } catch (Exception ex) {
                    logger.LogInformation(nameof(CerrarSesion));
                    return false;
                }
            });
        }

        public Task<bool> CrearCuentaUsuario(CreateAccountData createAccountData) {
            return Task.Run(() => {
                try {
                    return applicationUserManager.CreateUserAccount(createAccountData);
                } catch (Exception ex) {
                    logger.LogInformation(nameof(CrearCuentaUsuario));
                    return false;
                }
            });
        }
    }
}
