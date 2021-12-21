using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesktopUI.Backend.Business.Manager.Interfaces;
using DesktopUI.Backend.Data.DataAccessManager.Interfaces;
using DesktopUI.Backend.Data.Database;

namespace DesktopUI.Backend.Business.Manager
{
    public class UserManager : IUserManager
    {
        private readonly IUserDam userDam;
        public UserManager(IUserDam userDam)
        {
            this.userDam = userDam;
        }

        public async Task<List<Usuario>> GetListaUsuariosAsync()
        {
            var listaUsuarios = Task.Run(() => userDam.GetAllUsersAsync());
            var listaUsuariosConEdad = Task.Run(() => userDam.GetAllUsersWithEdadAsync(12));

            await Task.WhenAll(listaUsuarios, listaUsuariosConEdad);

            var response = listaUsuarios?.Result?.Concat(listaUsuariosConEdad?.Result).ToList();
            return response;
        }

        public async Task<List<Usuario>> GetListaUsuariosWithDapperAsync()
        {
            var listaUsuarios = Task.Run(() => userDam.GetAllUsersWithDapperAsync());
            var listaUsuariosConEdad = Task.Run(() => userDam.GetAllUsersWithEdadWithDapperAsync(12));

            await Task.WhenAll(listaUsuarios, listaUsuariosConEdad);

            var response = listaUsuarios.Result?.Concat(listaUsuariosConEdad.Result).ToList();
            return response;
        }
    }
}
