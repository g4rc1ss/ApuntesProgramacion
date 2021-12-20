using CleanArchitecture.ApplicationCore.Dominio.Negocio.Filtros.UserDetail;
using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Negocio.UsersManager;
using CleanArchitecture.ApplicationCore.Shared.Peticiones.Request.Users.UserDetail;
using CleanArchitecture.ApplicationCore.Shared.Peticiones.Responses.User.Usuarios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CleanArchitecture.Presentacion.Ejemplo.Pages.Models.Usuarios.Detalle {
    public class UsuariosDetalleModal : PageModel {
        private readonly IUserDetailNegocio _userDetail;

        [BindProperty(SupportsGet = true)]
        public UserDetailRequest UserRequest { get; set; }

        public UserResponse UserResponse { get; set; }

        public UsuariosDetalleModal(IUserDetailNegocio userDetail) {
            _userDetail = userDetail;
        }

        public async Task<IActionResult> OnGet() {
            var filtro = new FiltroUser {
                IdUsuario = UserRequest.IdUsuario
            };
            UserResponse = await _userDetail.GetUser(filtro);

            return Page();
        }
    }
}
