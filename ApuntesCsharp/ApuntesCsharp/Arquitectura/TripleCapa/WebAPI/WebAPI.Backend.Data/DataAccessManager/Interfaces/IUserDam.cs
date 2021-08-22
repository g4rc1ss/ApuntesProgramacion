using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WebAPI.Backend.Data.Database.Identity;

namespace WebAPI.Backend.Data.DataAccessManager.Interfaces {
    public interface IUserDam {
        Task<IdentityResult> CreateUserAsync(User user, string password);
        Task<IdentityResult> CreateUserRoleAsync(User user, string role);
        Task<IdentityResult> DeleteUserAsync(User user);
        Task<SignInResult> LogInAsync(string user, string password, bool rememberMe);
        Task<bool> LogoutAsync();
    }
}
