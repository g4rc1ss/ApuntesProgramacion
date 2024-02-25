using IdentityServerCookie.Database.Entities;
using IdentityServerCookie.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServerCookie.Controllers.Account;

public class LoginController(SignInManager<User> signInManager) : Controller
{

    public IActionResult Index()
    {
        return View();
    }

    public async Task<ActionResult> LoginAsync(LoginViewModel login)
    {
        await signInManager.PasswordSignInAsync(login.NombreUsuario, login.Password, false, false);
        return LocalRedirect("/");
    }
}
