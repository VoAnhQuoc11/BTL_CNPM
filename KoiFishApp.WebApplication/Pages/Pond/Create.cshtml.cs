using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiFishApp.Repositories.Entities;
using KoiFishApp.Services.Interfaces;

namespace KoiFishApp.WebApplication.Pages.Pond
{
   public class CreateModel : PageModel
    {
        private readonly IPondServices _pondServices;

        public CreateModel(IPondServices pondServices)
        {
            _pondServices = pondServices;
        }

        public SelectList PondList { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            return Page();
        }

        [BindProperty]
        public KoiFishApp.Repositories.Entities.Pond Pond { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _pondServices.AddAsync(Pond);

            return RedirectToPage("./Index");
        }
    }
}
