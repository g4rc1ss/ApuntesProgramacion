using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DesktopUI.Backend.Business.Manager;
using DesktopUI.Backend.Data.Database;

namespace DesktopUI.Backend.Business.Actions {
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
