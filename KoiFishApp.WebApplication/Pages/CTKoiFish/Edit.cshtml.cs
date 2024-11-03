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
        private readonly KoiFishApp.Repositories.Entities.QlcktnContext _context;

        public EditModel(KoiFishApp.Repositories.Entities.QlcktnContext context)
        {
            _context = context;
        }

        [BindProperty]
        public KoiFish KoiFish { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var koifish =  await _context.KoiFishes.FirstOrDefaultAsync(m => m.KoiId == id);
            if (koifish == null)
            {
                return NotFound();
            }
            KoiFish = koifish;
           ViewData["PondId"] = new SelectList(_context.Ponds, "PondId", "PondId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(KoiFish).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KoiFishExists(KoiFish.KoiId))
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

        private bool KoiFishExists(int id)
        {
            return _context.KoiFishes.Any(e => e.KoiId == id);
        }
    }
}
