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
        public async Task<List<KoiGrowth>> GetGrowthRecordsByKoiFishIdAsync(int koiId)
        {
            return await _growthRepository.GetGrowthRecordsByKoiFishIdAsync(koiId);
        }

        public async Task<KoiGrowth> GetGrowthRecordByIdAsync(int koiGrowthId)
        {
            return await _growthRepository.GetGrowthRecordByIdAsync(koiGrowthId);
        }
        public async Task AddGrowthRecordAsync(KoiGrowth record)
        {
            await _growthRepository.AddGrowthRecordAsync(record);
        }
        public async Task UpdateGrowthRecordAsync(KoiGrowth record)
        {
            // Kiểm tra bản ghi có tồn tại không
            var existingRecord = await _growthRepository.GetGrowthRecordByIdAsync(record.KoiGrowthId);
            if (existingRecord == null)
            {
                throw new Exception("Record not found");
            }

            // Cập nhật các giá trị mới từ `record`
            existingRecord.Size = record.Size;
            existingRecord.Weight = record.Weight;
            existingRecord.Date = record.Date;
            existingRecord.Age = record.Age;

            // Lưu thay đổi vào cơ sở dữ liệu
            await _growthRepository.UpdateGrowthRecordAsync(existingRecord);
        }
        public async Task DeleteGrowthRecordAsync(int koiGrowthId)
        {
            await _growthRepository.DeleteGrowthRecordAsync(koiGrowthId);
        }
        public decimal CalculateFoodAmount(decimal weight, int age)
        {
            // Feeding rate phụ thuộc vào tuổi của cá Koi
            decimal feedingRate = age <= 1 ? 0.04m : 0.02m; // 4% cho cá nhỏ, 2% cho cá trưởng thành
            return weight * feedingRate;
        }


    }
}
