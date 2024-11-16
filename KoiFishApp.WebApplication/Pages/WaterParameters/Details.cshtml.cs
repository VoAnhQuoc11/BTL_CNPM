using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiFishApp.Repositories.Entities;
using KoiFishApp.Services.Interfaces;

namespace KoiFishApp.Pages.WaterParameters
{
    public class DetailsModel : PageModel
    {
        private readonly IWaterParameterServices _waterParameterServices;

        public DetailsModel(IWaterParameterServices waterParameterServices)
        {
            _waterParameterServices = waterParameterServices;
        }

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
    }
}