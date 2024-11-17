using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFishApp.Repositories.Entities;

namespace KoiFishApp.Repositories.Interfaces
{
    public interface IPondRepositories
    {
        Task<List<Pond>> GetAllPondsAsync();
        Task<Pond?> GetByIdAsync(int id);
        Task Add(Pond pond);
        Task Update(Pond pond);
        Task Delete(int id);
        Task SaveChangesAsync();
        Task<bool> isExistsAsync(int id);
    }
}
