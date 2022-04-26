using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Database.Identity;
using CleanArchitecture.Domain.Negocio.UsersDto;

namespace CleanArchitecture.ApplicationCore.InterfacesEjemplo.Data
{
    public interface IUserDam
    {
        Task<UserIdentityResponse> CreateUserAsync(User user, string password);
        Task<UserIdentityResponse> CreateUserRoleAsync(User user, string role);
        Task<UserIdentityResponse> DeleteUserAsync(User user);
        Task<UserIdentityResponse> LogInAsync(string user, string password, bool rememberMe);
        Task<UserIdentityResponse> LogoutAsync();
        Task<List<User>> GetListUsers();
    }
}
