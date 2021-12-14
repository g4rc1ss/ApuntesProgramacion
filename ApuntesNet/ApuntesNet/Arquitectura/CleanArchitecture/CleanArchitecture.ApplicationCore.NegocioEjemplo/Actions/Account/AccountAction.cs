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

        public Task<bool> InicioSesionAsync(string username, string password, bool rememberMe) {
            try {
                return applicationUserManager.LoginAsync(username, password, rememberMe);
            } catch (Exception) {
                logger.LogInformation(nameof(InicioSesionAsync));
                return Task.FromResult(false);
            }
        }

        public Task<bool> CerrarSesionAsync() {
            try {
                return applicationUserManager.LogoutAsync();
            } catch (Exception) {
                logger.LogInformation(nameof(CerrarSesionAsync));
                return Task.FromResult(false);
            }
        }

        public Task<bool> CrearCuentaUsuarioAsync(CreateAccountData createAccountData) {
            try {
                return applicationUserManager.CreateUserAccountAsync(createAccountData);
            } catch (Exception) {
                logger.LogInformation(nameof(CrearCuentaUsuarioAsync));
                return Task.FromResult(false);
            }
        }
    }
}
