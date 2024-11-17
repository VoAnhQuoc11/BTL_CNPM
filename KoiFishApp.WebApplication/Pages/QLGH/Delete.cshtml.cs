using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFishApp.Repositories.Entities;

namespace KoiFishApp.WebApplication.Pages.QLGH
{
    public class DeleteModel : PageModel
    {

        private readonly IProductsService _service;

        public DeleteModel(IProductsService service)
        {    
            _service = service;            
        }

        [BindProperty]
        public GioHang Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            int Id = 0;

            if (id == null)
            {
                Id = 0;
                return NotFound();
            }

            Id = (int)id;

            var product = await _service.FindProductInGioHangById(Id);

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

            var product = await _service.FindProductInGioHangById((int) id);
            if (product != null)
            {
                Product = product;
                _service.RemoveGioHang((int) id);
            }

            return RedirectToPage("./Index");
        }
    }
}
