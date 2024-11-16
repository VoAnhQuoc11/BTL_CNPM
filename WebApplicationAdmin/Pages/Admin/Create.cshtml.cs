using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiFishApp.Repositories.Entities;
using KoiFishApp.Sevices.Interfaces;

namespace KoiFishApp.WebApplication.Pages.Admin
{
    public class CreateModel : PageModel
    {
        private readonly IUserServices _services;

        public CreateModel(IUserServices services)
        {
            _services = services;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public User User { get; set; } = default!;



        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (string.IsNullOrWhiteSpace(User.Username))
            {
                ModelState.AddModelError("", "Tên đăng nhập không được để trống");
            }
            if (string.IsNullOrWhiteSpace(User?.Password))
            {
                ModelState.AddModelError("", "Mật khẩu không được để trống");
            }
            var existingUsers = await _services.Users();
            if (existingUsers.Any(u => u.Username.Equals(User.Username, StringComparison.OrdinalIgnoreCase)))
            {
                ModelState.AddModelError("User.Username", "Tên đăng nhập đã tồn tại. Vui lòng chọn tên khác.");
                return Page();
            }

            var result = await _services.AddUser(User);
            if (result)
            {
                return RedirectToPage("/Admin/Index");
            }
            else
            {

                ModelState.AddModelError("", "Đã có lỗi xảy ra khi thêm người dùng.");
                return Page();
            }


        }
    }
}
