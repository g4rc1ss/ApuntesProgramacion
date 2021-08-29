using System.Threading.Tasks;
using WebAPI.Backend.Business.BusinessManager.IdentityManager;

namespace WebAPI.Backend.Business.Actions.Account.Interfaces {
    public interface IAccountAction {
        Task<bool> CerrarSesion();
        Task<bool> CrearCuentaUsuario(CreateAccountData createAccountData);
        Task<bool> InicioSesion(string username, string password, bool rememberMe);
    }
}
