using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiFishApp.Repositories.Entities;
using KoiFishApp.Services.Interfaces;

namespace KoiFishApp.Pages.WaterParameters
{
    public class EditModel : PageModel
    {
        private readonly IWaterParameterServices _waterParameterServices;

        public EditModel(IWaterParameterServices waterParameterServices)
        {
            _waterParameterServices = waterParameterServices;
        }

        [BindProperty]
        public WaterParameter WaterParameter { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            WaterParameter = await _waterParameterServices.GetWaterParameterByIdAsync(id);

            if (WaterParameter == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _waterParameterServices.UpdateWaterParameterAsync(WaterParameter);
            }
            catch (KeyNotFoundException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while updating the water parameter.");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}