using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiFishApp.Repositories.Entities;
using KoiFishApp.Services.Interfaces;

namespace KoiFishApp.WebApplication.Pages.Pond
{
    public class DetailsModel : PageModel
    {
        private readonly IPondServices _services;

        public KoiFishApp.Repositories.Entities.Pond Pond { get; set; } = default!;

        public DetailsModel(IPondServices services)
        {
            _services = services;
        }

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
    }
}
