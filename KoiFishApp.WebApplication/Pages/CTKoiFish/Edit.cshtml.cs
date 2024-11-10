using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiFishApp.Repositories.Entities;

namespace KoiFishApp.WebApplication.Pages.CTKoiFish
{
    public class EditModel : PageModel
    {
        private readonly IKoiFishServices _services;

        public EditModel(IKoiFishServices services)
        {
            _services = services;
        }

        [BindProperty]
        public KoiFish KoiFish { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var koifish = await _services.GetKoiFishByIdAsync(id.Value);
            if (koifish == null)
            {
                return NotFound();
            }
            KoiFish = koifish;

            var ponds = await _services.GetAllPondsAsync();
            ViewData["PondId"] = new SelectList(ponds, "PondId", "PondId");

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
                await _services.UpdateKoiFishAsync(KoiFish);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _services.KoiFishExistsAsync(KoiFish.KoiId))
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
