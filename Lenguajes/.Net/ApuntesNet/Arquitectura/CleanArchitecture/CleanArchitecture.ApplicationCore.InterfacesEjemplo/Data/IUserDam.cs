using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Database.Identity;
using CleanArchitecture.Domain.Negocio.UsersDto;

namespace CleanArchitecture.ApplicationCore.InterfacesEjemplo.Data
{
    public interface IUserDam
    {
        Task<bool> CreateUserAsync(UserData userData, string password);
        Task<bool> CreateUserRoleAsync(UserData userData, string role);
        Task<bool> DeleteUserAsync(UserData user);
        Task<bool> LogInAsync(string user, string password, bool rememberMe);
        Task<bool> LogoutAsync();
        Task<List<User>> GetListUsers();
    }
}
