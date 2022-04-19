using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Database.Identity;
using CleanArchitecture.Domain.Negocio.UsersDto;

namespace CleanArchitecture.ApplicationCore.InterfacesEjemplo.Negocio.UsersManager;

public interface IUserNegocio
{
    Task<bool> CreateUserAccountAsync(CreateAccountData createAccountData);
    Task<List<User>> GetListaUsuarios();
    Task<bool> LoginAsync(string username, string password, bool rememberMe);
    Task<bool> LogoutAsync();
}
