using KoiFishApp.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFishApp.Repositories.Interfaces
{
    public interface IKoiFishGrowthRepository
    {
        Task<List<KoiGrowth>> GetGrowthRecordsByKoiFishIdAsync(int koiId);
        Task<KoiGrowth> GetGrowthRecordByIdAsync(int koiGrowthId);
        Task AddGrowthRecordAsync(KoiGrowth record);
        Task UpdateGrowthRecordAsync(KoiGrowth record);
        Task DeleteGrowthRecordAsync(int recordId);
    }
}
