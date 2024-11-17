using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiFishApp.Services.Interfaces;
using KoiFishApp.Repositories.Entities;

namespace KoiFishApp.Pages.Pond
{
    public class CreateModel : PageModel
    {
        private readonly IPondServices _pondServices;

        [BindProperty]
        public KoiFishApp.Repositories.Entities.Pond Pond { get; set; } = new KoiFishApp.Repositories.Entities.Pond();

        public CreateModel(IPondServices pondServices)
        {
            _pondServices = pondServices;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Kiểm tra nếu Pond ID đã tồn tại trong cơ sở dữ liệu
            var existing = await _pondServices.GetByIdAsync(Pond.PondId);
            if (existing != null)
            {
                ModelState.AddModelError("Pond.PondId", "ID này đã được sử dụng. Vui lòng chọn ID khác.");
                return Page();
            }

            // Thêm Pond mới vào cơ sở dữ liệu
            await _pondServices.AddAsync(Pond);

            // Chuyển hướng đến trang Index sau khi lưu thành công
            return RedirectToPage("./Index");
        }
    }
}
