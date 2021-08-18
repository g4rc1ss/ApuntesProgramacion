using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WebAPI.Backend.Business.Actions.Account.Interfaces;
using WebAPI.Backend.Business.BusinessManager.IdentityManager;
using WebAPI.Backend.Business.BusinessManager.IdentityManager.Interfaces;

namespace WebAPI.Backend.Business.Actions.Account {
    internal class AccountAction : IAccountAction {
        private readonly ILogger<AccountAction> logger;
        private readonly IApplicationUserManager applicationUserManager;

        public AccountAction(ILogger<AccountAction> logger, IApplicationUserManager applicationUserManager) {
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
