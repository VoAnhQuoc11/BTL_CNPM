using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiFishApp.Repositories.Entities;
using KoiFishApp.Services.Interfaces;

namespace KoiFishApp.WebApplication.Pages.CTKoiFish
{
    public class IndexModel : PageModel
    {
        private readonly IKoiFishServices _services;

        public IndexModel(IKoiFishServices services)
        {
            _services = services;
        }

        public IList<KoiFish> KoiFish { get; set; } = default!;

        public async Task OnGetAsync()
        {
            KoiFish = await _services.KoiFish();
        }
    }
}
