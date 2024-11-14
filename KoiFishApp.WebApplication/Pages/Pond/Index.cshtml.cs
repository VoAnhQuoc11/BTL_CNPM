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
    public class IndexModel : PageModel
    {
        private readonly IPondServices _services;

        public IndexModel(IPondServices services)
        {
            _services = services;
        }

        public IList<KoiFishApp.Repositories.Entities.Pond> Pond { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Pond = await _services.GetAllPondsAsync();
        }
    }
}
