using AutoMapper;
using CleanArchitecture.Domain.Negocio.Filtros.UserDetail;
using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Negocio.UsersManager;
using CleanArchitecture.Shared.Peticiones.Request.Users.UserDetail;
using CleanArchitecture.Shared.Peticiones.Responses.User.Usuarios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CleanArchitecture.Ejemplo.Pages.Models.Usuarios.Detalle
{
    public class UsuariosDetalleModal : PageModel
    {
        private readonly IUserDetailNegocio _userDetail;
        private readonly IMapper _mapper;

        [BindProperty(SupportsGet = true)]
        public UserDetailRequest UserRequest { get; set; }

        public UserResponse UserResponse { get; set; }

        public UsuariosDetalleModal(IUserDetailNegocio userDetail, IMapper mapper)
        {
            _userDetail = userDetail;
            _mapper = mapper;
        }

        public async Task<IActionResult> OnGet()
        {
            var filtro = _mapper.Map<FiltroUser>(UserRequest);
            UserResponse = _mapper.Map<UserResponse>(await _userDetail.GetUser(filtro));

            return Page();
        }
    }
}
