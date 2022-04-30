using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Negocio.UsersManager;
using CleanArchitecture.Shared.Peticiones.Request.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CleanArchitecture.Ejemplo.RazorPages.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly IUserNegocio _userNegocio;

        public LoginModel(IUserNegocio userNegocio)
        {
            _userNegocio = userNegocio;
        }

        [BindProperty]
        public LoginRequest LoginRequest { get; set; }
        [BindProperty]
        public string ReturnUrl { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostLoginAsync()
        {
            await _userNegocio.LoginAsync(LoginRequest.UserName, LoginRequest.Password, false);

            return LocalRedirect("/");
        }
    }
}
