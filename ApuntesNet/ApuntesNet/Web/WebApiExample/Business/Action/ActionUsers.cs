using WebApiExample.Business.Manager;
using WebApiExample.Shared.DTO.Request;

namespace WebApiExample.Business.Action
{
    public class ActionUsers : IActionUsers
    {
        private readonly IUserManager _userManager;
        private readonly ILogger<ActionUsers> _logger;

        public ActionUsers(IUserManager userManager, ILogger<ActionUsers> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            try
            {
                return await _userManager.GetAllUser();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new List<User>();
            }
        }

        public async Task<bool> InsertUser(UserRequest userRequest)
        {
            try
            {
                return await _userManager.InsertUser(userRequest);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
    }
}
