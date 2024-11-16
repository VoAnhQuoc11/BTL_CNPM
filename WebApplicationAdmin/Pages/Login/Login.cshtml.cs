using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiFishApp.Repositories.Entities;
using KoiFishApp.Sevices.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace KoiFishApp.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IUserServices _services;

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string? ErrorMessage { get; set; }

        public LoginModel(IUserServices services)
        {
            _services = services;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = _services.GetUserByUsernameAndPassword(Username, Password);
            if (user == null)
            {
                ErrorMessage = "Invalid username or password.";
                return Page();
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Id), // Sử dụng user.Id để xác định người dùng
                new Claim(ClaimTypes.NameIdentifier, user.Username)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            // Đăng nhập người dùng bằng cookie
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            return RedirectToPage("/Admin/Index");
        }
    }
}

