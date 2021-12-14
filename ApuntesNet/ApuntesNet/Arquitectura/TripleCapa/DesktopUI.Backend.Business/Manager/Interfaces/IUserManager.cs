using System.Collections.Generic;
using System.Threading.Tasks;
using DesktopUI.Backend.Data.Database;

namespace DesktopUI.Backend.Business.Manager.Interfaces {
    public interface IUserManager {
        Task<List<Usuario>> GetListaUsuariosAsync();
        Task<List<Usuario>> GetListaUsuariosWithDapperAsync();
    }
}
