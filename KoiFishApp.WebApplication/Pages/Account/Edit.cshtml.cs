using KoiFishApp.Repositories.Entities;
using KoiFishApp.Sevices;
using KoiFishApp.Sevices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace KoiFishApp.WebApplication.Pages.Account
{

    public class EditModel : PageModel
    {
        private readonly IUserServices _services;

        public EditModel(IUserServices services)
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

        public async Task<IActionResult> OnPostAsync()
        {


            var userId = HttpContext.User.Identity.Name;

            bool status = User.Status ?? false;
            string image = User.Image ?? string.Empty;
            DateOnly birthDate = User.BirthDate ?? DateOnly.FromDateTime(DateTime.Now);
            bool gender = User.Gender ?? false;
            try
            {

                bool fullNameUpdated = await _services.UpdateFullNameAsync(userId, User.FullName);
                bool emailUpdated = await _services.UpdateEmailAsync(userId, User.Email);
                bool phoneUpdated = await _services.UpdatePhoneAsync(userId, User.Phone);
                bool statusUpdated = await _services.UpdateStatusAsync(userId, User.Status ?? false);
                bool imageUpdated = await _services.UpdateImageAsync(userId, User.Image ?? string.Empty);
                bool birthDateUpdated = await _services.UpdateBirthDateAsync(userId, User.BirthDate ?? DateOnly.FromDateTime(DateTime.Now));
                bool genderUpdated = await _services.UpdateGenderAsync(userId, User.Gender ?? false);

                if (!fullNameUpdated || !emailUpdated || !phoneUpdated || !statusUpdated || !imageUpdated || !birthDateUpdated || !genderUpdated)
                {
                    ModelState.AddModelError(string.Empty, "Cập nhật thông tin không thành công.");
                    return Page();
                }

                return RedirectToPage("/Account/Info");
            }
            catch (Exception ex)
            {
                // Xử lý lỗi khi có ngoại lệ
                ModelState.AddModelError(string.Empty, $"Đã xảy ra lỗi: {ex.Message}");
                return Page();
            }
        }
    }
}
