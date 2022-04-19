using AutoMapper;
using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Negocio.UsersManager;
using CleanArchitecture.Shared.Peticiones.Responses.User.Usuarios;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Ejemplo.API.Controllers.Usuarios.Lista
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListaUsuariosController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserNegocio _userNegocio;

        public ListaUsuariosController(IMapper mapper, IUserNegocio userNegocio)
        {
            _mapper = mapper;
            _userNegocio = userNegocio;
        }

        [HttpGet(nameof(ObtenerListadoUsuarios))]
        public async Task<IActionResult> ObtenerListadoUsuarios()
        {
            var usersResponse = _mapper.Map<List<UserResponse>>(await _userNegocio.GetListaUsuarios());

            return Json(usersResponse);
        }
    }
}
