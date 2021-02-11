using DataAccessLayer.DataAccessManager;
using DataAccessLayer.Database.Identity;
using Garciss.Core.Common.Respuestas;
using InmobiliariaEguzkimendi.Core.BusinessManager.IdentityManager;
using Microsoft.Extensions.Logging;
using System;

namespace BackApi.BusinessManager.IdentityManager {
    public class ApplicationUserManager {
        private readonly ILogger<ApplicationUserManager> logger;
        private readonly UserDam userDam;
        public ApplicationUserManager(ILogger<ApplicationUserManager> logger, UserDam userDam) {
            this.logger = logger;
            this.userDam = userDam;
        }

        public Respuesta Login(string username, string password, bool rememberMe) {
            var resp = userDam.LogInAsync(username, password, rememberMe).Result;
            if (!resp.Succeeded)
                return new Respuesta(4000, $"Nombre de usuario {username} o contraseña incorrecta ***", nameof(Login), logger);
            return new Respuesta();
        }

        public Respuesta Logout() {
            var resp = userDam.LogoutAsync().Result;
            if (!resp)
                return new Respuesta(4002, "Error al Cerrar la sesion", nameof(Logout), logger);
            return new Respuesta();
        }

        public Respuesta CreateUserAccount(CreateAccountData createAccountData) {
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
                if (resp.Resultado != resp.OK)
                    return resp;
            } else {
                var deleteToRevertOperation = userDam.DeleteUserAsync(user).Result;
                return new Respuesta(4003, $"usuario creado? {respUser.Succeeded} \n , logger" +
                    $"usuario insertado Rol? {respRole.Succeeded}", nameof(CreateUserAccount));
            }
            return new Respuesta();
        }
    }
}
