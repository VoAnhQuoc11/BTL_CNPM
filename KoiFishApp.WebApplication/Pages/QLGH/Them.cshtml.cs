using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiFishApp.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using KoiFishApp.Repositories.Entities;

namespace KoiFishApp.WebApplication.Pages.QLGH
{
    public class ThemModel : PageModel
    {
        private readonly IProductsService _service;
        private readonly QlcktnContext _context;
        public ThemModel(IProductsService service, QlcktnContext context)
        {
            _service = service;
            _context = context;
        }

        public IList<Product> Products { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            // Load products from the database
            Products = await _service.GetCurrentListItems();
            return Page();
        }

        [BindProperty]
        public int ProductId { get; set; }

        public async Task<IActionResult> OnPostAddToCartAsync()
        {
            // Tìm sản phẩm với ProductId trong bảng GioHangs
            var existingProduct = await _service.FindProductInGioHangById(ProductId);

            if (existingProduct == null)
            {
                // Tạo một bản sao của sản phẩm nếu sản phẩm đã tồn tại trong giỏ hàng
                var infoProduct = await _service.GetProductById(ProductId);
                var newProduct = new GioHang
                {
                    ProductId = infoProduct.ProductId,
                    Name = infoProduct.Name,
                    Price = infoProduct.Price,
                    Quantity = infoProduct.Quantity * 0 + 1,
                    Description = infoProduct.Description
                    // Lưu ý rằng ProductId sẽ được tự động tạo mới nếu cột này là tự tăng
                };

                // Thêm bản sao vào cơ sở dữ liệu
                _service.AddGioHang(newProduct);
            }
            else
            {
                existingProduct.Quantity += 1;
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
