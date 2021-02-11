using Electron.NET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Electron.NET.Controllers {
    public class HomeController :Controller {
        private readonly ILogger<HomeController> logger;

        public HomeController(ILogger<HomeController> logger) {
            this.logger = logger;
        }

        public IActionResult Index() {
            return new LocalRedirectResult("/Login");
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
