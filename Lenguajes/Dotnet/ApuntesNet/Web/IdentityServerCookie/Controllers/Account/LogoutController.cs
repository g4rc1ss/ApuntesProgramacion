using IdentityServerCookie.Database.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServerCookie.Controllers.Account;

public class LogoutController(SignInManager<User> signInManager) : Controller
{

    public async Task<IActionResult> IndexAsync()
    {
        await signInManager.SignOutAsync();

        return LocalRedirect("/");
    }
}
