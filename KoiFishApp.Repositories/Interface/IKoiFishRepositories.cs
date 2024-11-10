using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFishApp.Repositories.Interface
{
        public interface IKoiFishRepositories
    {
        Task<List<KoiFish>> GetAllKoiFish();
        Task AddKoiFish(KoiFish koiFish);
        //
        Task DeleteKoiFishAsync(int id);
        Task<KoiFish?> GetKoiFishByIdAsync(int id);
        Task<List<Pond>> GetAllPondsAsync();
        Task UpdateKoiFishAsync(KoiFish koiFish);
        Task<bool> KoiFishExistsAsync(int id);
    }
}
