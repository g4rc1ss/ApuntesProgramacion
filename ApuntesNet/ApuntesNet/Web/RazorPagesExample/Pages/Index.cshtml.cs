using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesExample.Business.Action;
using RazorPagesExample.Business.Manager;

namespace RazorPagesExample.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IUserAction _userAction;

        public List<User> Usuarios { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IUserAction userAction)
        {
            _logger = logger;
            _userAction = userAction;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Usuarios = (await _userAction.GetAllUsersAsync()).ToList();
            return Page();
        }
    }
}
