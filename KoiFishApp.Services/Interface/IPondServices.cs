using KoiFishApp.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFishApp.Services.Interfaces
{
    public interface IPondServices
    {
        Task<List<Pond>> GetAllPondsAsync();
    }
}
