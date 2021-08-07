using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Business.Manager;
using Backend.Data.Database;

namespace Backend.Business.Actions {
    public class UserAction {
        private readonly UserManager userManager;
        public UserAction(UserManager userManager) {
            this.userManager = userManager;
        }

        public Task<List<Usuario>> GetAllUsers() {
            return Task.Run(() => {
                try {
                    return userManager.GetListaUsuarios();
                } catch (Exception) {
                    return new List<Usuario>();
                }
            });
        }
    }
}
