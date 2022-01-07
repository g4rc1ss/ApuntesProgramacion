using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.ApplicationCore.Domain.Negocio.UsersDto;
using CleanArchitecture.Shared.Peticiones.Responses.User.Usuarios;

namespace CleanArchitecture.ApplicationCore.InterfacesEjemplo.Data
{
    public interface IUserDam
    {
        Task<bool> CreateUserAsync(UserData userData, string password);
        Task<bool> CreateUserRoleAsync(UserData userData, string role);
        Task<bool> DeleteUserAsync(UserData user);
        Task<bool> LogInAsync(string user, string password, bool rememberMe);
        Task<bool> LogoutAsync();
        Task<List<UserResponse>> GetListUsers();
    }
}
