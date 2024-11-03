using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiFishApp.Repositories.Entities;
using KoiFishApp.Services.Interfaces;

namespace KoiFishApp.WebApplication.Pages.CTKoiFish
{
   public class CreateModel : PageModel
    {
        private readonly IKoiFishServices _koiFishServices;
        private readonly IPondServices _pondServices;

        public CreateModel(IKoiFishServices koiFishServices, IPondServices pondServices)
        {
            _koiFishServices = koiFishServices;
            _pondServices = pondServices;
        }

        public SelectList PondList { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            var ponds = await _pondServices.GetAllPondsAsync();
            PondList = new SelectList(ponds, "PondId", "PondId"); // Thay đổi tên nếu muốn hiển thị tên hồ

            return Page();
        }

        [BindProperty]
        public KoiFish KoiFish { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _koiFishServices.AddKoiFishAsync(KoiFish);

            return RedirectToPage("./Index");
        }
    }
}
