using AutoMapper;
using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Negocio.UsersManager;
using CleanArchitecture.Domain.Negocio.Filtros.UserDetail;
using CleanArchitecture.Shared.Peticiones.Request.Users.UserDetail;
using CleanArchitecture.Shared.Peticiones.Responses.User.Usuarios;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Ejemplo.API.Controllers.Usuarios.Detalle
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosDetalleController : Controller
    {
        private readonly IUserDetailNegocio _userDetail;
        private readonly IMapper _mapper;

        public UsuariosDetalleController(IUserDetailNegocio userDetail, IMapper mapper)
        {
            _userDetail = userDetail;
            _mapper = mapper;
        }

        [HttpPost(nameof(ObtenerDetalleUsuarioPost))]
        public async Task<IActionResult> ObtenerDetalleUsuarioPost(UserDetailRequest userRequest)
        {
            var filtro = _mapper.Map<FiltroUser>(userRequest);
            var userResponse = _mapper.Map<UserResponse>(await _userDetail.GetUser(filtro));

            return Json(userResponse);
        }

        [HttpGet("ObtenerDetalleUsuarioGet/{id}")]
        public async Task<IActionResult> ObtenerDetalleUsuarioGet(int id)
        {
            var filtro = _mapper.Map<FiltroUser>(id);
            var userResponse = _mapper.Map<UserResponse>(await _userDetail.GetUser(filtro));

            return Json(userResponse);
        }
    }
}
