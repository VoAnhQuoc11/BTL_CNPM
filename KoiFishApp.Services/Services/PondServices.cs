using KoiFishApp.Repositories.Entities;
using KoiFishApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFishApp.Services.Services
{
    public class PondServices : IPondServices
    {
        private readonly QlcktnContext _context;

        public PondServices(QlcktnContext context)
        {
            _context = context;
        }

        public async Task<List<Pond>> GetAllPondsAsync()
        {
            return await _context.Ponds.ToListAsync();
        }
    }
}
