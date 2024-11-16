using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiFishApp.Repositories.Entities;
using KoiFishApp.Sevices.Interfaces;

namespace KoiFishApp.WebApplication.Pages.Admin
{
    public class EditModel : PageModel
    {
        private readonly IUserServices _services;

        public EditModel(IUserServices services)
        {
            _services = services;
        }

        [BindProperty]
        public User User { get; set; } = default!;


        public async Task<IActionResult> OnGetAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return NotFound();
            }


            User = await _services.GetUserByIdAsync(userId);

            if (User == null)
            {
                return NotFound();
            }

            return Page();
        }

        // Lưu thông tin người dùng đã chỉnh sửa
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Cập nhật thông tin người dùng
            var result = await _services.UpUser(User);

            if (result)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ModelState.AddModelError("", "Có lỗi xảy ra khi cập nhật người dùng.");
                return Page();
            }
        }


    }




}