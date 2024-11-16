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
    public class IndexModel : PageModel
    {
        private readonly IUserServices _services;

        public IndexModel(IUserServices services)
        {
            _services = services;
        }

        public List<User> Users { get; set; } = new List<User>();
        public async Task<IActionResult> OnGetAsync()
        {

            Users = await _services.Users();
            return Page();
        }
    }
}
