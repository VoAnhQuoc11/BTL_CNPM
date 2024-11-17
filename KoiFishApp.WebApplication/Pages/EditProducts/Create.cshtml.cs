using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiCare.Repositories.Enteteis;
using KoiCare.Repositories.Interfaces;
using KoiCare.Services.Interfaces;

namespace KoiCare.WebApplication.Pages.EditProducts
{
    public class CreateModel : PageModel
    {
        private readonly QlcktnContext _context;

        private readonly IProductsService _service;

        public CreateModel(QlcktnContext context, IProductsService service)
        {
            _context = context;
            _service = service;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            if (_service.AddProduct(Product))
            {
                _context.SaveChanges();
            }


            return RedirectToPage("./Index");
        }
    }
}
