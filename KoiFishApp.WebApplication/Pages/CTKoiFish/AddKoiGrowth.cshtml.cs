using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiFishApp.Repositories.Entities;
using KoiFishApp.Services.Interfaces;

namespace KoiFishApp.WebApplication.Pages.CTKoiFish
{
    public class AddKoiGrowthModel : PageModel
    {
        private readonly IKoiFishGrowthService _growthRecordService;
        private readonly IKoiFishServices _koiFishService;

        public AddKoiGrowthModel(IKoiFishGrowthService growthRecordService, IKoiFishServices koiFishService)
        {
            _growthRecordService = growthRecordService;
            _koiFishService = koiFishService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            // Sử dụng IKoiFishServices để lấy danh sách KoiFish
            var koiFishList = await _koiFishService.KoiFish();
            ViewData["KoiId"] = new SelectList(koiFishList, "KoiId", "KoiId");
            return Page();
        }

        [BindProperty]
        public KoiGrowth KoiGrowth { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _growthRecordService.AddGrowthRecordAsync(KoiGrowth);
            return RedirectToPage("/CTKoiFish/Details", new { id = KoiGrowth.KoiId });
        }
    }
}
