using AutoMapper;
using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Negocio.UsersManager;
using CleanArchitecture.Shared.Peticiones.Request.Users;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Ejemplo.API.Controllers.Usuarios
{
    [ApiController]
    [Route("api/[controller]")]
    public class SignController : Controller
    {
        private readonly IUserNegocio _user;
        private readonly IMapper _mapper;

        public SignController(IUserNegocio userDetail, IMapper mapper)
        {
            _user = userDetail;
            _mapper = mapper;
        }

        [HttpPost(nameof(Login))]
        public async Task<IActionResult> Login(LoginRequest login)
        {
            var succeed = await _user.LoginAsync(login.UserName, login.Password, false);

            return Json(succeed);
        }

        [HttpGet(nameof(LogOut))]
        public async Task<IActionResult> LogOut()
        {
            var succeed = await _user.LogoutAsync();

            return Json(succeed);
        }
    }
}
