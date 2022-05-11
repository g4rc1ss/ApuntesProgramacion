using IdentityServerCookie.Database.Entities;
using IdentityServerCookie.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServerCookie.Controllers.Account
{
    public class LoginController : Controller
    {
        private readonly SignInManager<User> _signInManager;

        public LoginController(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index(object s)
        {
            return View();
        }

        public async Task<ActionResult> LoginAsync(LoginViewModel login)
        {
            await _signInManager.PasswordSignInAsync(login.NombreUsuario, login.Password, false, false);
            return LocalRedirect("/");
        }
    }
}
