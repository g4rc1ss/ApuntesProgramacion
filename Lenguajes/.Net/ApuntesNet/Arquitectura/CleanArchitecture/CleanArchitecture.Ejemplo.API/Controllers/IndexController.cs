using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Ejemplo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IndexController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Json(null);
        }
    }
}
