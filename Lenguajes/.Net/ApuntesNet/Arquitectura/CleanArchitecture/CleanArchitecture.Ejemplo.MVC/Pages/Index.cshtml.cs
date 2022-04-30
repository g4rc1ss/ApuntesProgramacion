using AutoMapper;
using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Negocio.UsersManager;
using CleanArchitecture.Shared.Peticiones.Responses.User.Usuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CleanArchitecture.Ejemplo.RazorPages.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IMapper _mapper;
        private readonly IUserNegocio _userNegocio;

        public IEnumerable<UserResponse> UserResponse { get; set; }

        public IndexModel(IUserNegocio userNegocio, IMapper mapper)
        {
            _userNegocio = userNegocio;
            _mapper = mapper;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var users = await _userNegocio.GetListaUsuarios();
            UserResponse = _mapper.Map<IEnumerable<UserResponse>>(users);

            return Page();
        }
    }
}
