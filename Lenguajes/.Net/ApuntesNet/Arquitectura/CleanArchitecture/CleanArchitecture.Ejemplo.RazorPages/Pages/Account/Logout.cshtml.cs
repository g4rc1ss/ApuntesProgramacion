using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Negocio.UsersManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CleanArchitecture.Ejemplo.RazorPages.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private readonly IUserNegocio _userNegocio;

        public LogoutModel(IUserNegocio userNegocio)
        {
            _userNegocio = userNegocio;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            await _userNegocio.LogoutAsync();

            return LocalRedirect("/");
        }
    }
}
