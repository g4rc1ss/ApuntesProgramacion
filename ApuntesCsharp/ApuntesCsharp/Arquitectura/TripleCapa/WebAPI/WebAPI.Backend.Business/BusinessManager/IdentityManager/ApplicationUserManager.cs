using System;
using DataAccessLayer.DataAccessManager;
using DataAccessLayer.Database.Identity;
using Microsoft.Extensions.Logging;

namespace WebAPI.Backend.Business.BusinessManager.IdentityManager {
    public class ApplicationUserManager {
        private readonly ILogger<ApplicationUserManager> logger;
        private readonly UserDam userDam;
        public ApplicationUserManager(ILogger<ApplicationUserManager> logger, UserDam userDam) {
            this.logger = logger;
            this.userDam = userDam;
        }

        public bool Login(string username, string password, bool rememberMe) {
            var resp = userDam.LogInAsync(username, password, rememberMe).Result;
            if (!resp.Succeeded) {
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
                UserName = createAccountData.UserName,
                NormalizedUserName = createAccountData.NormalizedUserName,
                Email = createAccountData.Email,
                PhoneNumber = createAccountData.PhoneNumber,
                SecurityStamp = new Guid().ToString()
            };
            var respUser = userDam.CreateUserAsync(user, createAccountData.Password).Result;
            var respRole = userDam.CreateUserRoleAsync(user, "Usuario").Result;

            if (respUser.Succeeded && respRole.Succeeded) {
                var resp = Login(createAccountData.UserName, createAccountData.Password, false);
                return resp;
            } else {
                var deleteToRevertOperation = userDam.DeleteUserAsync(user).Result;
                logger.LogInformation($"usuario creado? {respUser.Succeeded} \n , logger" +
                    $"usuario insertado Rol? {respRole.Succeeded}", nameof(CreateUserAccount));
                return false;
            }
        }
    }
}
