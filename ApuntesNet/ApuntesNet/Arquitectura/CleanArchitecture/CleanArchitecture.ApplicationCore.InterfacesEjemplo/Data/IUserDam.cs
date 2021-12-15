using System.Threading.Tasks;
using CleanArchitecture.ApplicationCore.Dominio.EntidadesDatabase.Identity;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.ApplicationCore.InterfacesEjemplo.Data {
    public interface IUserDam {
        Task<IdentityResult> CreateUserAsync(User user, string password);
        Task<IdentityResult> CreateUserRoleAsync(User user, string role);
        Task<IdentityResult> DeleteUserAsync(User user);
        Task<SignInResult> LogInAsync(string user, string password, bool rememberMe);
        Task<bool> LogoutAsync();
    }
}
