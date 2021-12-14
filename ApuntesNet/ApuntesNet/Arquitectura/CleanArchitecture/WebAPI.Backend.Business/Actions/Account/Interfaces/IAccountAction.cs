using System.Threading.Tasks;
using WebAPI.Backend.Business.BusinessManager.IdentityManager;

namespace WebAPI.Backend.Business.Actions.Account.Interfaces {
    public interface IAccountAction {
        Task<bool> CerrarSesionAsync();
        Task<bool> CrearCuentaUsuarioAsync(CreateAccountData createAccountData);
        Task<bool> InicioSesionAsync(string username, string password, bool rememberMe);
    }
}
