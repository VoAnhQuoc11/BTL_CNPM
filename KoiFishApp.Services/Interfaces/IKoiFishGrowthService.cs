using KoiFishApp.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFishApp.Services.Interfaces
{
    public interface IKoiFishGrowthService
    {
        Task<List<KoiGrowth>> GetGrowthRecordsByKoiFishIdAsync(int koiId);
        Task<KoiGrowth> GetGrowthRecordByIdAsync(int koiGrowthId);
        Task AddGrowthRecordAsync(KoiGrowth record);
        Task UpdateGrowthRecordAsync(KoiGrowth record);
        Task DeleteGrowthRecordAsync(int recordId);
        decimal CalculateFoodAmount(decimal weight, int age);
    }
}
