using System.Security.Claims;
using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Negocio.UsersManager;
using CleanArchitecture.Domain.OptionsConfig;
using CleanArchitecture.Shared.Peticiones.Request.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace CleanArchitecture.Ejemplo.RazorPages.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly IUserNegocio _userNegocio;
        private readonly InfraestructureConfiguration _infraestructureConfig;

        public LoginModel(IUserNegocio userNegocio, IOptions<InfraestructureConfiguration> infraestructureConfig)
        {
            _userNegocio = userNegocio;
            _infraestructureConfig = infraestructureConfig.Value;
        }

        [BindProperty(SupportsGet = true)]
        public LoginRequest LoginRequest { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ReturnUrl { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnGetLoginAsync()
        {
            return await OnPostLoginAsync();
        }

        public async Task<IActionResult> OnPostLoginAsync()
        {

            var loginInfo = await _userNegocio.LoginAsync(LoginRequest.UserName, LoginRequest.Password, false);

            if ((_infraestructureConfig.UseIdentity.HasValue && !_infraestructureConfig.UseIdentity.Value)
                || !_infraestructureConfig.UseIdentity.HasValue)
            {
                var identity = new ClaimsIdentity("Cookies");
                identity.AddClaim(new Claim(ClaimTypes.Role, loginInfo.RoleModel.Name));
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, loginInfo.UserModel.Id.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Name, $"{loginInfo.UserModel.UserName}"));

                var prop = new AuthenticationProperties { IsPersistent = false };
                await HttpContext.SignInAsync("Cookies", new ClaimsPrincipal(identity), prop);
            }

            return LocalRedirect(ReturnUrl ?? "/");
        }
    }
}
