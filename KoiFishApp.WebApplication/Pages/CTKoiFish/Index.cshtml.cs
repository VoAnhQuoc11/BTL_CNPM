using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFishApp.Repositories.Entities;
using KoiFishApp.Services.Interfaces;
using KoiFishApp.Services;

namespace KoiFishApp.WebApplication.Pages.CTKoiFish
{
    public class IndexModel : PageModel
    {
        private readonly IKoiFishServices _services;

        public IndexModel(IKoiFishServices services)
        {
            _services = services;
        }

        public IList<KoiFish> KoiFish { get; set; } = default!;
        public Dictionary<int, decimal> FoodAmounts { get; set; } = new Dictionary<int, decimal>(); // Khai báo FoodAmounts
        public async Task OnGetAsync()
        {
            KoiFish = await _services.KoiFish();
            // Tính toán lượng thức ăn cho mỗi cá Koi
            foreach (var koi in KoiFish)
            {
                var foodAmount = await _services.CalculateFoodAmount(koi.KoiId);
                FoodAmounts[koi.KoiId] = foodAmount;  // Lưu kết quả vào dictionary
            }
        }
    }
}
