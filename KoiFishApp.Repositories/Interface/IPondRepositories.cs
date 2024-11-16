using KoiFishApp.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFishApp.Repositories.Interface
{
        public interface IPondRepositories
    {
        Task<List<Pond>> GetAll();
        Task Add(Pond pond);
        Task Update(Pond pond); 
        Task Delete(Pond pond);
        //
        Task<Pond?> GetByIdAsync(int id);
        Task SaveChangesAsync();
        Task<bool> isExistsAsync(int id);
        Task<List<Pond>> GetAllPondsAsync();
        Task<Pond> GetPondByIdAsync(int pondId);
    }
}
