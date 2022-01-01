using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DesktopUI.Backend.Business.Actions.Interfaces;
using DesktopUI.Backend.Business.Manager.Interfaces;
using DesktopUI.Backend.Data.Database;

namespace DesktopUI.Backend.Business.Actions
{
    public class UserAction : IUserAction
    {
        private readonly IUserManager userManager;
        public UserAction(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        public Task<List<Usuario>> GetAllUsers()
        {
            try
            {
                return userManager.GetListaUsuariosAsync();
            }
            catch (Exception)
            {
                return Task.FromResult(new List<Usuario>());
            }
        }

        public Task<List<Usuario>> GetAllUsersWithDapper()
        {
            try
            {
                return userManager.GetListaUsuariosWithDapperAsync();
            }
            catch (Exception)
            {
                return Task.FromResult(new List<Usuario>());
            }
        }
    }
}
