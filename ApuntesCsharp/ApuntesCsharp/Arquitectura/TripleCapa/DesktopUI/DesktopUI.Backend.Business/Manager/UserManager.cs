using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesktopUI.Backend.Business.Manager.Interfaces;
using DesktopUI.Backend.Data.DataAccessManager;
using DesktopUI.Backend.Data.DataAccessManager.Interfaces;
using DesktopUI.Backend.Data.Database;

namespace DesktopUI.Backend.Business.Manager {
    public class UserManager : IUserManager {
        private readonly IUserDam userDam;
        public UserManager(IUserDam userDam) {
            this.userDam = userDam;
        }

        public List<Usuario> GetListaUsuarios() {
            var listaUsuarios = default(List<Usuario>);
            var listaUsuariosConEdad = default(List<Usuario>);

            Parallel.Invoke(
                () => {
                    listaUsuarios = userDam.GetAllUsers();
                },
                () => {
                    listaUsuariosConEdad = userDam.GetAllUsersWithEdad(12);
                });
            var response = listaUsuarios?.Concat(listaUsuariosConEdad).ToList();
            return response;
        }
    }
}
