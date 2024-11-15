
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiFishApp.Services.Interfaces;
using KoiFishApp.Repositories.Entities;

namespace KoiFishApp.Pages.WaterParameters
{
    public class CreateModel : PageModel
    {
        private readonly IWaterParameterServices _waterParameterServices;

        [BindProperty]
        public WaterParameter WaterParameter { get; set; } = new WaterParameter();

        public CreateModel(IWaterParameterServices waterParameterServices)
        {
            _waterParameterServices = waterParameterServices;
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

            // Kiểm tra nếu ID đã tồn tại trong cơ sở dữ liệu
            var existing = await _waterParameterServices.GetWaterParameterByIdAsync(WaterParameter.Id);
            if (existing != null)
            {
                // Thêm lỗi vào ModelState nếu ID đã được sử dụng
                ModelState.AddModelError("WaterParameter.Id", "ID này đã được sử dụng. Vui lòng chọn ID khác.");
                return Page();
            }

            // Nếu ID không tồn tại, thêm WaterParameter vào cơ sở dữ liệu
            await _waterParameterServices.AddWaterParameterAsync(WaterParameter);

            // Chuyển hướng đến trang chỉ mục sau khi lưu thành công
            return RedirectToPage("./Index");
        }

    }
}
