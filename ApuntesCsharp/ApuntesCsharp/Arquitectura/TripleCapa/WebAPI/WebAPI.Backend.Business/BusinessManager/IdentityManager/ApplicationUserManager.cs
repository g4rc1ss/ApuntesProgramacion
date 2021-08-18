using System;
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

        public bool Login(string username, string password, bool rememberMe) {
            var resp = userDam.LogInAsync(username, password, rememberMe).Result;
            if (resp is null || !resp.Succeeded) {
                logger.LogInformation($"Nombre de usuario {username} o contraseña incorrecta ***", nameof(Login));
                return false;
            }
            return true;
        }

        public bool Logout() {
            var resp = userDam.LogoutAsync().Result;
            if (!resp) {
                logger.LogInformation("Error al Cerrar la sesion", nameof(Logout));
                return false;
            }
            return true;
        }

        public bool CreateUserAccount(CreateAccountData createAccountData) {
            var user = new User() {
                UserName = createAccountData?.UserName,
                NormalizedUserName = createAccountData?.NormalizedUserName,
                Email = createAccountData?.Email,
                PhoneNumber = createAccountData?.PhoneNumber,
                SecurityStamp = new Guid().ToString()
            };
            var respUser = userDam.CreateUserAsync(user, createAccountData?.Password).Result;
            var respRole = userDam.CreateUserRoleAsync(user, "Usuario").Result;

            if (respUser is not null && respRole is not null && respUser.Succeeded && respRole.Succeeded) {
                var resp = Login(createAccountData?.UserName, createAccountData?.Password, false);
                return resp;
            } else {
                var deleteToRevertOperation = userDam.DeleteUserAsync(user).Result;
                logger.LogInformation($"usuario creado? {respUser?.Succeeded} \n , logger" +
                    $"usuario insertado Rol? {respRole?.Succeeded}", nameof(CreateUserAccount));
                return false;
            }
        }
    }
}
