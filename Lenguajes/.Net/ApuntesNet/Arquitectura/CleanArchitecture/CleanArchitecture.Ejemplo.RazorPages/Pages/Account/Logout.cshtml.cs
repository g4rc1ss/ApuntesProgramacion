using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Negocio.UsersManager;
using CleanArchitecture.Domain.OptionsConfig;
using CleanArchitecture.Infraestructure.DataEntityFramework.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace CleanArchitecture.Ejemplo.RazorPages.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly InfraestructureConfiguration _infraestructureConfig;

        public LogoutModel(IOptions<InfraestructureConfiguration> infraestructureConfig, IServiceProvider serviceProvider)
        {
            _infraestructureConfig = infraestructureConfig.Value;
            _serviceProvider = serviceProvider;
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
                var identitySignIn = _serviceProvider.GetRequiredService<SignInManager<User>>();
                await identitySignIn.SignOutAsync();
            }

            return LocalRedirect("/");
        }
    }
}
