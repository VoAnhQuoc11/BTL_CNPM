using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiFishApp.Services.Interfaces;
using KoiFishApp.Repositories.Entities;

namespace KoiFishApp.Pages.WaterParameters
{
    public class DeleteModel : PageModel
    {
        private readonly IWaterParameterServices _waterParameterServices;

        public DeleteModel(IWaterParameterServices waterParameterServices)
        {
            _waterParameterServices = waterParameterServices;
        }

        [BindProperty]
        public WaterParameter WaterParameter { get; set; } = new WaterParameter();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            WaterParameter = await _waterParameterServices.GetWaterParameterByIdAsync(id);

            if (WaterParameter == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var waterParameter = await _waterParameterServices.GetWaterParameterByIdAsync(id);

            if (waterParameter == null)
            {
                return NotFound();
            }

            await _waterParameterServices.DeleteWaterParameterAsync(id);
            return RedirectToPage("./Index");
        }
    }
}
