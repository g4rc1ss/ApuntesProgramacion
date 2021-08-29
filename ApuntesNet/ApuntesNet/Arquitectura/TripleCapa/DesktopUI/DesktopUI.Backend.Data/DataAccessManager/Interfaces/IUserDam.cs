using System.Collections.Generic;
using DesktopUI.Backend.Data.Database;

namespace DesktopUI.Backend.Data.DataAccessManager.Interfaces {
    public interface IUserDam {
        List<Usuario> GetAllUsers();
        List<Usuario> GetAllUsersWithEdad(int edad);
    }
}
