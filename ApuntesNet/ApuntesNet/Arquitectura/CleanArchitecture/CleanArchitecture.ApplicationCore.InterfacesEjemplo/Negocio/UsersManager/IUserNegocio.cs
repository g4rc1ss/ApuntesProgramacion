using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.ApplicationCore.Dominio.Negocio.UsersDto;
using CleanArchitecture.ApplicationCore.Shared.Peticiones.Responses.User.Usuarios;

namespace CleanArchitecture.ApplicationCore.InterfacesEjemplo.Negocio.UsersManager;

public interface IUserNegocio {
    Task<bool> CreateUserAccountAsync(CreateAccountData createAccountData);
    Task<List<UserResponse>> GetListaUsuarios();
    Task<bool> LoginAsync(string username, string password, bool rememberMe);
    Task<bool> LogoutAsync();
}
