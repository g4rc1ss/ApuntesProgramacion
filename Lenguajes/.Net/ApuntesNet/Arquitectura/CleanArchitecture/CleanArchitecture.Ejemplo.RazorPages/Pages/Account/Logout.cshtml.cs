using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Negocio.UsersManager;
using CleanArchitecture.Domain.OptionsConfig;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace CleanArchitecture.Ejemplo.RazorPages.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private readonly IUserNegocio _userNegocio;
        private readonly InfraestructureConfiguration _infraestructureConfig;

        public LogoutModel(IUserNegocio userNegocio, IOptions<InfraestructureConfiguration> infraestructureConfig)
        {
            _userNegocio = userNegocio;
            _infraestructureConfig = infraestructureConfig.Value;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if ((_infraestructureConfig.UseIdentity.HasValue && !_infraestructureConfig.UseIdentity.Value)
                || !_infraestructureConfig.UseIdentity.HasValue)
            {
                await HttpContext.SignOutAsync();
            }
            else
            {
                
            }

            return LocalRedirect("/");
        }
    }
}
