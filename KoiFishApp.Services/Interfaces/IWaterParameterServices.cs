using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFishApp.Repositories.Entities;
using KoiFishApp.Services.Services;

namespace KoiFishApp.Services.Interfaces
{
    public interface IWaterParameterServices
    {
        Task<List<WaterParameter>> GetAllWaterParametersAsync();
        Task<WaterParameter> GetWaterParameterByIdAsync(int id);
        Task<List<WaterParameter>> GetWaterParametersByPondIdAsync(int pondId);
        Task AddWaterParameterAsync(WaterParameter waterParameter);
        Task UpdateWaterParameterAsync(WaterParameter waterParameter);
        Task DeleteWaterParameterAsync(int id);
        Task AddWaterParameterForPondIdAsync(int pondId);

        // Updated method signatures
        Task<WaterParameter> GetSuggestedWaterParametersAsync(int pondId);
        string GetWaterParameterSuggestion(WaterParameter parameter);
    }
}
