using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiFishApp.Repositories.Entities;
using KoiFishApp.Services.Interfaces;
using Microsoft.CodeAnalysis.Emit;
using KoiFishApp.Services.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KoiFishApp.WebApplication.Pages.CTKoiFish
{
    public class EditGrowthRecordModel : PageModel
    {
        private readonly IKoiFishGrowthService _growthRecordService;
        public KoiGrowth _temp { get; set; }
        public EditGrowthRecordModel(IKoiFishGrowthService growthRecordService)
        {
            _growthRecordService = growthRecordService;

        }

        // public int ID { get; set; }
        [BindProperty]
        public KoiGrowth KoiGrowth { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int koiGrowthId)
        {
            // Lấy thông tin bản ghi tăng trưởng
            KoiGrowth = await _growthRecordService.GetGrowthRecordByIdAsync(koiGrowthId);

            if (KoiGrowth == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int koiGrowthId)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _growthRecordService.UpdateGrowthRecordAsync(KoiGrowth);
            return Page();
        }

    }
}
