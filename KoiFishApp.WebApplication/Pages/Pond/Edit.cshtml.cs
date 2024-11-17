using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFishApp.Services.Interfaces;
using KoiFishApp.Repositories.Entities;


namespace KoiFishApp.Pages.Pond
{
    public class EditModel : PageModel
    {
        private readonly IPondServices _pondServices;

        public EditModel(IPondServices pondServices)
        {
            _pondServices = pondServices;
        }

        [BindProperty]
        public KoiFishApp.Repositories.Entities.Pond Pond { get; set; } = new KoiFishApp.Repositories.Entities.Pond();

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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _pondServices.UpdateAsync(Pond);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _pondServices.isExistsAsync(Pond.PondId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
