using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiFishApp.Repositories.Entities;
using KoiFishApp.Services.Interfaces;

namespace KoiFishApp.WebApplication.Pages.CTKoiFish
{
    public class DetailsModel : PageModel
    {
        private readonly IKoiFishServices _services;
        private readonly IPondServices _pondServices;
        private readonly IKoiFishGrowthService _growthRecordServices;

        public DetailsModel(IKoiFishServices services, IPondServices pondServices, IKoiFishGrowthService growthRecordServices)
        {
            _services = services;
            _pondServices = pondServices;
            _growthRecordServices = growthRecordServices;
        }

        public KoiFish KoiFish { get; set; } = new KoiFish();
        public KoiFishApp.Repositories.Entities.Pond Pond { get; set; } = new KoiFishApp.Repositories.Entities.Pond();
        public decimal FoodAmount { get; set; }
        public List<KoiGrowth> GrowthRecords { get; set; } = new List<KoiGrowth>();
        // Khai báo FoodAmounts dưới dạng Dictionary để lưu giá trị FoodAmount cho từng GrowthRecord
        public Dictionary<int, decimal> FoodAmounts { get; set; } = new Dictionary<int, decimal>();



        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            KoiFish = await _services.GetKoiFishByIdAsync(id.Value);
            if (KoiFish == null)
            {
                return NotFound();
            }

            FoodAmount = await _services.CalculateFoodAmount(KoiFish.KoiId);
            GrowthRecords = await _growthRecordServices.GetGrowthRecordsByKoiFishIdAsync(id.Value) ?? new List<KoiGrowth>();

            if (KoiFish.PondId.HasValue)
            {
                Pond = await _pondServices.GetByIdAsync(KoiFish.PondId.Value);
            }

            return Page();
        }

    }
}
