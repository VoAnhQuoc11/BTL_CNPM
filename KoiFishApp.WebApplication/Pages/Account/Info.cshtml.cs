using KoiFishApp.Repositories.Entities;
using KoiFishApp.Sevices.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiFishApp.WebApplication.Pages.Account
{
    [Authorize]
    public class InfoModel : PageModel
    {
        private readonly IUserServices _services;

        public InfoModel(IUserServices services)
        {
            _services = services;
        }

        [BindProperty]
        public User User { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var userId = HttpContext.User.Identity.Name;

            User = await _services.GetUserByIdAsync(userId);

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

