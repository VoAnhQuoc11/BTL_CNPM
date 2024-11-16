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
    public class KoiFishGrowthService : IKoiFishGrowthService
    {
        private readonly IKoiFishGrowthRepository _growthRepository;

        public KoiFishGrowthService(IKoiFishGrowthRepository growthRepository)
        {
            _growthRepository = growthRepository;
        }

        public async Task<List<KoiGrowth>> GetGrowthRecordsAsync(int koiId)
        {
            return await _growthRepository.GetGrowthRecordsByKoiFishIdAsync(koiId);
        }

        public async Task AddGrowthRecordAsync(int koiId, double size, double weight)
        {
            var record = new KoiGrowth
            {
                KoiId = koiId,
                Date = DateTime.Now,
                Size = size,
                Weight = weight
            };
            await _growthRepository.AddGrowthRecordAsync(record);
        }
        public async Task<List<KoiGrowth>> GetGrowthRecordsByKoiFishIdAsync(int koiId)
        {
            return await _growthRepository.GetGrowthRecordsByKoiFishIdAsync(koiId);
        }
        public async Task AddGrowthRecordAsync(KoiGrowth record)
        {
            await _growthRepository.AddGrowthRecordAsync(record);
        }

        public async Task UpdateGrowthRecordAsync(KoiGrowth record)
        {
            await _growthRepository.UpdateGrowthRecordAsync(record);
        }

        public async Task DeleteGrowthRecordAsync(int recordId)
        {
            await _growthRepository.DeleteGrowthRecordAsync(recordId);
        }
    }
}
