using AutoMapper;
using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Negocio.UsersManager;
using CleanArchitecture.Domain.Negocio.UsersDto;
using CleanArchitecture.Shared.Peticiones.Request.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CleanArchitecture.Ejemplo.RazorPages.Pages.Account
{
    public class CreateAccountModel : PageModel
    {
        private readonly IUserNegocio _userNegocio;
        private readonly IMapper _mapper;


        [BindProperty]
        public CreateUserRequest CreateUserRequest { get; set; }

        public CreateAccountModel(IUserNegocio userNegocio, IMapper mapper)
        {
            _userNegocio = userNegocio;
            _mapper = mapper;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostCreateAccountAsync()
        {
            var createAccount = _mapper.Map<CreateAccountData>(CreateUserRequest);
            var succeed = await _userNegocio.CreateUserAccountAsync(createAccount);

            if (succeed)
            {
                return RedirectToPage("/Account/Login", "Login", new
                {
                    createAccount.UserName,
                    createAccount.Password
                });
            }
            return Page();
        }
    }
}
