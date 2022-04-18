using AutoMapper;
using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Negocio.UsersManager;
using CleanArchitecture.Shared.Peticiones.Responses.User.Usuarios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CleanArchitecture.Ejemplo.Pages.Models
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IMapper _mapper;
        private readonly IUserNegocio _userNegocio;

        internal List<UserResponse> UsersResponse { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IUserNegocio userNegocio, IMapper mapper)
        {
            _logger = logger;
            _userNegocio = userNegocio;
            _mapper = mapper;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            UsersResponse = _mapper.Map<List<UserResponse>>(await _userNegocio.GetListaUsuarios());
            return Page();
        }
    }
}
