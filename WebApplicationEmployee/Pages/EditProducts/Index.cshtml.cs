using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFishApp.Repositories.Enteteis;
using KoiFishApp.Services.Interfaces;

namespace KoiFishApp.WebApplication.Pages.EditProducts
{
    public class IndexModel : PageModel
    {
        private readonly QlcktnContext _context;
        private readonly IProductsService _productsService;

        public IndexModel(QlcktnContext context, IProductsService productsService)
        {
            _productsService = productsService;
            _context = context;
        }

        public IList<Product> Product { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Product = await _productsService.GetCurrentListItems();
        }
    }
}
