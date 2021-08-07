using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WebAPI.Backend.Business.BusinessManager.IdentityManager;

namespace WebAPI.Backend.Business.Actions.Identity {
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
                } catch (Exception) {
                    logger.LogInformation(nameof(CerrarSesion));
                    return false;
                }
            });
        }

        public Task<bool> CrearCuentaUsuario(CreateAccountData createAccountData) {
            return Task.Run(() => {
                try {
                    return applicationUserManager.CreateUserAccount(createAccountData);
                } catch (Exception) {
                    logger.LogInformation(nameof(CrearCuentaUsuario));
                    return false;
                }
            });
        }
    }
}
