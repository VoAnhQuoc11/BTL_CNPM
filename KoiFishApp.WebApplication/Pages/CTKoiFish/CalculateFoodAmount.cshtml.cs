using KoiFishApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiFishApp.WebApplication.Pages.CTKoiFish
{
    public class CalculateFoodAmountModel : PageModel
    {
        private readonly IKoiFishServices _services;

        public CalculateFoodAmountModel(IKoiFishServices services)
        {
            _services = services;
        }

        [BindProperty]
        public int KoiFishId { get; set; }
        public decimal FoodAmount { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (KoiFishId <= 0)
            {
                ModelState.AddModelError(string.Empty, "Invalid KoiFish ID.");
                return Page();
            }

            try
            {
                // Tính toán lượng thức ăn dựa trên ID cá Koi
                FoodAmount = await _services.CalculateFoodAmount(KoiFishId);
                return Page();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page();
            }
        }
    }

}
