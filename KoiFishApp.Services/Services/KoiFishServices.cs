using KoiFishApp.Repositories.Entities;
using KoiFishApp.Repositories.Interfaces;
using KoiFishApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFishApp.Services.Services
{
    public class KoiFishServices : IKoiFishServices
    {
        private readonly IKoiFishRepositories _repositories;
        public KoiFishServices(IKoiFishRepositories repositories)
        {
            _repositories = repositories;
        }

        public Task<List<KoiFish>> KoiFish()
        {
            return _repositories.GetAllKoiFish();
        }
        public async Task AddKoiFishAsync(KoiFish koiFish)
        {
            await _repositories.AddKoiFish(koiFish);
        }
        //
        public async Task DeleteKoiFishAsync(int id)
        {
            var koiFish = await _repositories.GetKoiFishByIdAsync(id);
            if (koiFish != null)
            {
                _repositories.DeleteKoiFish(koiFish);
                await _repositories.SaveChangesAsync();
            }
        }
        public async Task<KoiFish?> GetKoiFishByIdAsync(int id)  // Triển khai phương thức này
        {
            return await _repositories.GetKoiFishByIdAsync(id);
        }
        public async Task UpdateKoiFishAsync(KoiFish koiFish)
        {
            _repositories.UpdateKoiFish(koiFish);
            await _repositories.SaveChangesAsync();
        }

        public async Task<bool> KoiFishExistsAsync(int id)
        {
            return await _repositories.KoiFishExistsAsync(id);
        }

        public async Task<List<Pond>> GetAllPondsAsync()
        {
            return await _repositories.GetAllPondsAsync();
        }
       

    }
}
