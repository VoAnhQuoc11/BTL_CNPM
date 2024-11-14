using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFishApp.Repositories.Entities;
using KoiFishApp.Services.Interfaces;

namespace KoiFishApp.WebApplication.Pages.Pond
{
    public class DeleteModel : PageModel
    {
        private readonly IPondServices _services;

        public DeleteModel(IPondServices services)
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
            else
            {
                this.Pond = pond;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _services.DeleteAsync(id.Value);

            return RedirectToPage("./Index");
        }
    }
}
