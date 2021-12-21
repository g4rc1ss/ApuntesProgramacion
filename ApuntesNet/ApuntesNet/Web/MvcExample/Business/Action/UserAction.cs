using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MvcExample.Business.Manager;

namespace MvcExample.Business.Action {
    public class UserAction : IUserAction {
        private readonly IUserManager _userManager;
        private readonly ILogger<UserAction> _logger;

        public UserAction(IUserManager userManager, ILogger<UserAction> logger) {
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync() {
            try {
                return await _userManager.GetAllUser();
            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                return new List<User>();
            }
        }
    }
}
