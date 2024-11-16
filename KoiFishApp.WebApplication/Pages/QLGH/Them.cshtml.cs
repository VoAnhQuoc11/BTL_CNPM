using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiFishApp.Repositories.Entities
    ;
using Microsoft.EntityFrameworkCore;

using KoiFishApp.Repositories.Entities;

namespace KoiFishApp.WebApplication.Pages.QLGH
{
    public class ThemModel : PageModel
    {
        private readonly QlcktnContext _context;

        public ThemModel(QlcktnContext context)
        {
            _context = context;
        }

        public IList<Product> Products { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            // Load products from the database
            Products = await _context.Products.ToListAsync();
            return Page();
        }

        [BindProperty]
        public int ProductId { get; set; }

        public async Task<IActionResult> OnPostAddToCartAsync()
        {
            // Tìm sản phẩm với ProductId trong bảng GioHangs
            var existingProduct = await _context.GioHangs.FindAsync(ProductId);

            if (existingProduct == null)
            {
                // Tạo một bản sao của sản phẩm nếu sản phẩm đã tồn tại trong giỏ hàng
                var infoProduct = await _context.Products.FindAsync(ProductId);
                var newProduct = new GioHang
                {
                    ProductId = infoProduct.ProductId,
                    Name = infoProduct.Name,
                    Price = infoProduct.Price,
                    Quantity = infoProduct.Quantity * 0 + 1,
                    Description = infoProduct.Description                    
                };

                // Thêm bản sao vào cơ sở dữ liệu
                _context.GioHangs.Add(newProduct);
                await _context.SaveChangesAsync();
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
