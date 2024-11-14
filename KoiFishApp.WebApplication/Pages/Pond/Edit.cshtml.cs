using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiFishApp.Repositories.Entities;
using KoiFishApp.Services.Interfaces;

namespace KoiFishApp.WebApplication.Pages.Pond
{
    public class EditModel : PageModel
    {
        private readonly IPondServices _services;

        public EditModel(IPondServices services)
        {
            _services = services;
        }

        [BindProperty]
        public KoiFishApp.Repositories.Entities.Pond Pond { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pond = await _services.GetByIdAsync(id.Value);
            if (pond == null)
            {
                return NotFound();
            }
            Pond = pond;

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
                await _services.UpdateAsync(Pond);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _services.isExistsAsync(Pond.PondId))
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
