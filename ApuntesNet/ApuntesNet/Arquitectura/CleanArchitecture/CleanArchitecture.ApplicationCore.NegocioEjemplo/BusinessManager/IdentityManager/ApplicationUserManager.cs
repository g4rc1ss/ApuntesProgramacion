using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WebAPI.Backend.Business.BusinessManager.IdentityManager.Interfaces;
using WebAPI.Backend.Data.DataAccessManager.Interfaces;
using WebAPI.Backend.Data.Database.Identity;

namespace WebAPI.Backend.Business.BusinessManager.IdentityManager {
    public class ApplicationUserManager : IApplicationUserManager {
        private readonly ILogger<ApplicationUserManager> logger;
        private readonly IUserDam userDam;
        public ApplicationUserManager(ILogger<ApplicationUserManager> logger, IUserDam userDam) {
            this.logger = logger;
            this.userDam = userDam;
        }

        public async Task<bool> LoginAsync(string username, string password, bool rememberMe) {
            var resp = await userDam.LogInAsync(username, password, rememberMe);
            if (resp is null || !resp.Succeeded) {
                logger.LogInformation($"Nombre de usuario {username} o contraseña incorrecta ***", nameof(LoginAsync));
                return false;
            }
            return true;
        }

        public async Task<bool> LogoutAsync() {
            var resp = await userDam.LogoutAsync();
            if (!resp) {
                logger.LogInformation("Error al Cerrar la sesion", nameof(LogoutAsync));
                return false;
            }
            return true;
        }

        public async Task<bool> CreateUserAccountAsync(CreateAccountData createAccountData) {
            var user = new User() {
                UserName = createAccountData?.UserName,
                NormalizedUserName = createAccountData?.NormalizedUserName,
                Email = createAccountData?.Email,
                PhoneNumber = createAccountData?.PhoneNumber,
                SecurityStamp = new Guid().ToString()
            };
            var respUser = await userDam.CreateUserAsync(user, createAccountData?.Password);
            var respRole = await userDam.CreateUserRoleAsync(user, "Usuario");

            if (respUser is not null && respRole is not null && respUser.Succeeded && respRole.Succeeded) {
                var resp = await LoginAsync(createAccountData?.UserName, createAccountData?.Password, false);
                return resp;
            } else {
                var deleteToRevertOperation = await userDam.DeleteUserAsync(user);
                logger.LogInformation($"usuario creado? {respUser?.Succeeded} \n , logger" +
                    $"usuario insertado Rol? {respRole?.Succeeded}", nameof(CreateUserAccountAsync));
                return false;
            }
        }
    }
}
