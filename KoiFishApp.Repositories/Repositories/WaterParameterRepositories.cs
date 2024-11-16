using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoiFishApp.Repositories.Entities;
using KoiFishApp.Repositories.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace KoiFishApp.Repositories.Reposotories
{
    public class WaterParameterRepositores : IWaterParameterRepositories
    {
        private readonly QlcktnContext _dbContext;

        public WaterParameterRepositores(QlcktnContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<WaterParameter>> GetAllWaterParametersAsync()
        {
            return await _dbContext.WaterParameters.ToListAsync();
        }

        public async Task<WaterParameter> GetWaterParameterByIdAsync(int id)
        {
            var waterParameter = await _dbContext.WaterParameters.SingleOrDefaultAsync(wp => wp.Id == id);
            if (waterParameter == null)
            {
                return null;
            }
            return waterParameter;
        }

        public async Task<List<WaterParameter>> GetWaterParametersByPondIdAsync(int pondId)
        {
            return await _dbContext.WaterParameters.Where(wp => wp.PondId == pondId).ToListAsync();
        }

        public async Task AddWaterParameterAsync(WaterParameter waterParameter)
        {
            _dbContext.WaterParameters.Add(waterParameter);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateWaterParameterAsync(WaterParameter waterParameter)
        {
            var existing = await _dbContext.WaterParameters.FindAsync(waterParameter.Id);

            if (existing != null)
            {
                // Update properties individually to avoid issues with tracking
                existing.MeasurementDate = waterParameter.MeasurementDate;
                existing.Temperature = waterParameter.Temperature;
                existing.Salinity = waterParameter.Salinity;
                existing.Ph = waterParameter.Ph;
                existing.O2 = waterParameter.O2;
                existing.No2 = waterParameter.No2;
                existing.No3 = waterParameter.No3;
                existing.Po4 = waterParameter.Po4;
                existing.PondId = waterParameter.PondId;

                // Mark the entity as modified to ensure changes are tracked
                _dbContext.Entry(existing).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"WaterParameter with ID {waterParameter.Id} not found.");
            }
        }
        public async Task DeleteWaterParameterAsync(int id)
        {
            var waterParameter = await _dbContext.WaterParameters.FindAsync(id);
            if (waterParameter != null)
            {
                _dbContext.WaterParameters.Remove(waterParameter);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task AddWaterParameterForPondIDAsync(int pondId)
        {
            var defaultWaterParameter = new WaterParameter
            {
                PondId = pondId,
                Temperature = 22.0,
                Salinity = 0.1,
                Ph = 7.5,
                O2 = 8.0,
                No2 = 0.0,
                No3 = 25.0,
                Po4 = 1.0,
                MeasurementDate = DateTime.Now
            };

            _dbContext.WaterParameters.Add(defaultWaterParameter);
            await _dbContext.SaveChangesAsync();
        }
    }
}
