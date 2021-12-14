using System.Collections.Generic;
using System.Threading.Tasks;
using DesktopUI.Backend.Data.Database;

namespace DesktopUI.Backend.Business.Actions.Interfaces {
    public interface IUserAction {
        Task<List<Usuario>> GetAllUsers();
        Task<List<Usuario>> GetAllUsersWithDapper();
    }
}
