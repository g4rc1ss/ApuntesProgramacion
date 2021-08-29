using System.Collections.Generic;
using DesktopUI.Backend.Data.Database;

namespace DesktopUI.Backend.Business.Manager.Interfaces {
    public interface IUserManager {
        List<Usuario> GetListaUsuarios();
    }
}
