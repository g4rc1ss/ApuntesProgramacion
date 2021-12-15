using System;
using System.Threading.Tasks;
using CleanArchitecture.ApplicationCore.DataEjemplo.DataAccessManager.DamBase;
using CleanArchitecture.ApplicationCore.Dominio.EntidadesDatabase.Identity;
using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Data;
using CleanArchitecture.Infraestructure.DatabaseConfig;
using Microsoft.AspNetCore.Identity;

namespace WebAPI.Backend.Data.DataAccessManager {
    public class UserDam : DataAccessManagerBase, IUserDam {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;

        public UserDam(WebApiPruebaContext webApiPruebaContext, SignInManager<User> signInManager, UserManager<User> userManager) : base(webApiPruebaContext) {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public async Task<SignInResult> LogInAsync(string user, string password, bool rememberMe) {
            return await signInManager.PasswordSignInAsync(user, password, rememberMe, false);
        }

        public async Task<bool> LogoutAsync() {
            try {
                await signInManager.SignOutAsync();
                return true;
            } catch (Exception) {
                return false;
            }
        }

        public async Task<IdentityResult> CreateUserAsync(User user, string password) {
            return await userManager.CreateAsync(user, password);
        }

        public async Task<IdentityResult> CreateUserRoleAsync(User user, string role) {
            return await userManager.AddToRoleAsync(user, role);
        }

        public async Task<IdentityResult> DeleteUserAsync(User user) {
            return await userManager.DeleteAsync(user);
        }
    }
}
