using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFishApp.Repositories.Entities;
using KoiFishApp.Sevices.Interfaces;

namespace KoiFishApp.WebApplication.Pages.Admin
{
    public class DetailsModel : PageModel
    {
        private readonly IUserServices _services;


        public DetailsModel(IUserServices services)
        {
            _services = services;
        }

        public User User { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return NotFound();
            }

            User = await _services.GetUserByIdAsync(userId);

            if (User == null)
            {
                return NotFound();
            }

            return Page();
        }
    }

}
