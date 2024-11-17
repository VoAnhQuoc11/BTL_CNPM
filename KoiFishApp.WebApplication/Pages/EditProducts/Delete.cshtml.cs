using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiCare.Repositories.Enteteis;
using KoiCare.Services.Interfaces;

namespace KoiCare.WebApplication.Pages.EditProducts
{
    public class DeleteModel : PageModel
    {
        private readonly IProductsService _service;

        private readonly QlcktnContext _context;
        public DeleteModel(IProductsService service, QlcktnContext context)
        {
            _service = service;
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            int Id = 0;
            if (id == null)
            {
                Id = 0;
                return NotFound();
            }
            Id = (int)id;

            var product = await _service.GetProductById(Id);

            if (product == null)
            {
                return NotFound();
            }
            else
            {
                Product = product;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            


            if (id == null)
            {
                return NotFound();
            }

            var product = await _service.GetProductById((int) id);
            if (product != null)
            {
                Product = product;
                _service.RemoveProduct((int) id);
            }

            return RedirectToPage("./Index");
        }
    }
}
