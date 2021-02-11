using Apuntes.BackLocal.DataAccessLayer.DataAccessManager;
using Apuntes.BackLocal.DataAccessLayer.Database.Sqlite;
using Garciss.Core.Common.Respuestas;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apuntes.BackLocal.Core.Manager {
    public class UserManager {
        private readonly UserDam userDam;
        public UserManager(UserDam userDam) {
            this.userDam = userDam;
        }

        public Respuesta<List<Usuario>> GetListaUsuarios() {
            var listaUsuarios = default(List<Usuario>);
            var listaUsuariosConEdad = default(List<Usuario>);

            Parallel.Invoke(
                () => {
                    listaUsuarios = userDam.GetAllUsers();
                },
                () => {
                    listaUsuariosConEdad = userDam.GetAllUsersWithEdad(12);
                });
            var response = listaUsuarios.Concat(listaUsuariosConEdad).ToList();
            return new Respuesta<List<Usuario>>(response);
        }
    }
}
