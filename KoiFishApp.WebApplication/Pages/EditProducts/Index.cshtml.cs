using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiCare.Repositories.Enteteis;

namespace KoiCare.WebApplication.Pages.EditProducts
{
    public class IndexModel : PageModel
    {
        private readonly KoiCare.Repositories.Enteteis.QlcktnContext _context;

        public IndexModel(KoiCare.Repositories.Enteteis.QlcktnContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Product = await _context.Products.ToListAsync();
        }
    }
}
