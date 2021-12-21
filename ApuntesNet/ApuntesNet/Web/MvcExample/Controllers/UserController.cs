using Microsoft.AspNetCore.Mvc;
using MvcExample.Business.Action;
using MvcExample.Models;

namespace MvcExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserAction _userAction;

        public UserController(IUserAction userAction)
        {
            _userAction = userAction;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var response = await _userAction.GetAllUsersAsync();
            var userViewModel = new UserViewModel { Usuarios = response.ToList() };
            return View(userViewModel);
        }
    }
}
