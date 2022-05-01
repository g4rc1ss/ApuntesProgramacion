using AutoMapper;
using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Negocio.UsersManager;
using CleanArchitecture.Domain.Negocio.Filtros.UserDetail;
using CleanArchitecture.Shared.Peticiones.Request.Users.UserDetail;
using CleanArchitecture.Shared.Peticiones.Responses.User.Usuarios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CleanArchitecture.Ejemplo.RazorPages.Pages.Users
{
    public class UserDetailModel : PageModel
    {
        private readonly IMapper _mapper;
        private readonly IUserDetailNegocio _userDetailNegocio;

        [BindProperty(SupportsGet = true)]
        public UserDetailRequest UserDetailRequest { get; set; }

        public UserResponse UserResponse { get; set; }

        public UserDetailModel(IUserDetailNegocio userDetailNegocio, IMapper mapper)
        {
            _userDetailNegocio = userDetailNegocio;
            _mapper = mapper;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var filtro = _mapper.Map<FiltroUser>(UserDetailRequest);
            var users = await _userDetailNegocio.GetUser(filtro);
            UserResponse = _mapper.Map<UserResponse>(users);

            return Page();
        }
    }
}
