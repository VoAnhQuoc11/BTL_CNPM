using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFishApp.Repositories.Entities;
using KoiFishApp.Services.Interface;

namespace KoiFishApp.WebApplication.Pages.CTKoiFish
{
    public class DeleteModel : PageModel
    {
        private readonly IKoiFishServices _services;

        public DeleteModel(IKoiFishServices services)
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
            else
            {
                KoiFish = koifish;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _services.DeleteKoiFishAsync(id.Value);

            return RedirectToPage("./Index");
        }
    }
}
