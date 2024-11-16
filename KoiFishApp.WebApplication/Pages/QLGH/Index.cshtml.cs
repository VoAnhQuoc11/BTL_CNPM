using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFishApp.Repositories.Entities;


using KoiFishApp.Services.Interfaces;
using KoiFishApp.Services.Services;
using KoiFishApp.Repositories.Entities;

namespace KoiFishApp.WebApplication.Pages.QLGH
{
    public class IndexModel : PageModel
    {
        private readonly IProductsService _context;


        public IndexModel(IProductsService context)
        {
            _context = context;
        }

        public IList<GioHang> Product { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Product = await _context.GetGioHangHienTai();
        }
    }
}
