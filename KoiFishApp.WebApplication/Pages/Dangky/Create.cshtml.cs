using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiFishApp.Repositories.Entities;
using KoiFishApp.Repositories.Intrefaces;
using KoiFishApp.Sevices.Interfaces;

namespace KoiFishApp.WebApplication.Pages.Dangky
{
    public class CreateModel : PageModel
    {

        private readonly IUserServices _service;

        private readonly QlcktnContext _context;

        public CreateModel(QlcktnContext context, IUserServices service)
        {
            _context = context;
            _service = service;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public User User { get; set; }

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            User user = _service.CreateUser(User.Id, User.Username ?? string.Empty, User.FullName ?? string.Empty, User.Password ?? string.Empty, string.Empty,false, User.BirthDate ?? DateOnly.FromDateTime(DateTime.Now),string.Empty,false,string.Empty);


            _context.Users.Add (user);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Login/Login");
        }
    }
}
