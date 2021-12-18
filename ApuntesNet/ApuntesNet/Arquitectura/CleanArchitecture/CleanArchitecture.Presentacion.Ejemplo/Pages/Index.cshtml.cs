using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Negocio.UsersManager;
using CleanArchitecture.ApplicationCore.Shared.Peticiones.Responses.User.Usuarios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CleanArchitecture.Presentacion.Ejemplo.Pages {
    public class IndexModel : PageModel {
        private readonly ILogger<IndexModel> _logger;
        private readonly IUserNegocio _userNegocio;

        internal List<UserResponse> Users { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IUserNegocio userNegocio) {
            _logger = logger;
            _userNegocio = userNegocio;
        }

        public async Task<IActionResult> OnGetAsync() {
            Users = await _userNegocio.GetListaUsuarios();
            return Page();
        }
    }
}
