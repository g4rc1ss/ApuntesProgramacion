using Apuntes.BackLocal.Core.Manager;
using Apuntes.BackLocal.DataAccessLayer.Database.Sqlite;
using Garciss.Core.Common.Respuestas;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apuntes.BackLocal.Core.Actions {
    public class UserAction {
        private readonly UserManager userManager;
        public UserAction(UserManager userManager) {
            this.userManager = userManager;
        }

        public Task<Respuesta<List<Usuario>>> GetAllUsers() {
            return Task.Run(() => {
                try {
                    return userManager.GetListaUsuarios();
                } catch (Exception ex) {
                    return new Respuesta<List<Usuario>>(ex, nameof(GetAllUsers));
                }
            });
        }
    }
}
