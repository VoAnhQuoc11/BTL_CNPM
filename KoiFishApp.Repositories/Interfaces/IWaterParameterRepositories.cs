using KoiFishApp.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFishApp.Repositories.Interfaces
{
    public interface IWaterParameterRepositories
    {
        //Get all water parameters
        Task<List<WaterParameter>> GetAllWaterParametersAsync();

        //Get water parameter by ID
        Task<WaterParameter> GetWaterParameterByIdAsync(int id);

        // Get water parameters by pond ID
        Task<List<WaterParameter>> GetWaterParametersByPondIdAsync(int pondId);

        //Add new water parameter
        Task AddWaterParameterAsync(WaterParameter waterParameter);

        // Update existing water parameter
        Task UpdateWaterParameterAsync(WaterParameter waterParameter);

        // Delete water parameter by ID
        Task DeleteWaterParameterAsync(int id);

        // Add default water parameter for a pond
        Task AddWaterParameterForPondIDAsync(int pondId);
    }

}

