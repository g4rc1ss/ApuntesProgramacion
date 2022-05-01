using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Database.ModelEntity;
using CleanArchitecture.Domain.Negocio.UsersDto;

namespace CleanArchitecture.ApplicationCore.InterfacesEjemplo.Negocio.UsersManager;

public interface IUserNegocio
{
    Task<bool> CreateUserAccountAsync(CreateAccountData createAccountData);
    Task<List<UserModelEntity>> GetListaUsuarios();
    Task<LoginIdentityResponse> LoginAsync(string username, string password, bool rememberMe);
}
