using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiFishApp.Services.Interfaces;
using KoiFishApp.Repositories.Entities;


namespace KoiFishApp.Pages.Pond
{
    public class DetailsModel : PageModel
    {
        private readonly IPondServices _pondServices;

        public DetailsModel(IPondServices pondServices)
        {
            _pondServices = pondServices;
        }

        public KoiFishApp.Repositories.Entities.Pond Pond { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pond = await _pondServices.GetByIdAsync(id.Value);
            if (Pond == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
