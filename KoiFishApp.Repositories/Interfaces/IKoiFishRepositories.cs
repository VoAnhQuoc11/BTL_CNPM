using KoiFishApp.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFishApp.Repositories.Interfaces
{
    public interface IKoiFishRepositories
    {

        Task<List<KoiFish>> GetAllKoiFish();
        Task AddKoiFish(KoiFish koiFish);
        //
        void DeleteKoiFish(KoiFish koiFish);
        Task<KoiFish?> GetKoiFishByIdAsync(int id);
        Task SaveChangesAsync();
        void UpdateKoiFish(KoiFish koiFish);
        Task<bool> KoiFishExistsAsync(int id);
        Task<List<Pond>> GetAllPondsAsync();
    }
}
