using System.Collections.Generic;
using System.Threading.Tasks;
using DesktopUI.Backend.Data.Database;

namespace DesktopUI.Backend.Data.DataAccessManager.Interfaces {
    public interface IUserDam {
        Task<List<Usuario>> GetAllUsersAsync();
        Task<List<Usuario>> GetAllUsersWithEdadAsync(int edad);
    }
}
