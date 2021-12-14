using System.Threading.Tasks;

namespace WebAPI.Backend.Business.BusinessManager.IdentityManager.Interfaces {
    public interface IApplicationUserManager {
        Task<bool> CreateUserAccountAsync(CreateAccountData createAccountData);
        Task<bool> LoginAsync(string username, string password, bool rememberMe);
        Task<bool> LogoutAsync();
    }
}
