using AutoMapper;
using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Negocio.UsersManager;
using CleanArchitecture.Domain.Negocio.UsersDto;
using CleanArchitecture.Shared.Peticiones.Request.Users;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Ejemplo.API.Controllers.Usuarios
{
    [ApiController]
    [Route("api/[controller]")]
    public class CrearUsuarioController : Controller
    {

        private readonly IUserNegocio _userDetail;
        private readonly IMapper _mapper;

        public CrearUsuarioController(IUserNegocio userDetail, IMapper mapper)
        {
            _userDetail = userDetail;
            _mapper = mapper;
        }

        [HttpPost(nameof(CreateUser))]
        public async Task<IActionResult> CreateUser(CreateUserRequest userRequest)
        {
            var filtro = _mapper.Map<CreateAccountData>(userRequest);

            var succeed = await _userDetail.CreateUserAccountAsync(filtro);

            return Json(succeed);
        }
    }
}
