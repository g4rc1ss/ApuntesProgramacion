using Microsoft.AspNetCore.Mvc;
using Elec = Electron.NET.Models;

namespace Electron.NET.Controllers.Account {
    public class AccountController :Controller {

        [Route("/Login")]
        [HttpGet]
        public IActionResult Login() {
            return View();
        }

        [Route("/Login/Entry")]
        [HttpPost]
        public IActionResult Entry(Elec::LoginViewModel loginView) {
            return new LocalRedirectResult("/Login");
        }
    }
}
