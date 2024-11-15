using KoiFishApp.Repositories.Entities;
using KoiFishApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiFishApp.Pages.WaterParameters
{
    public class IndexModel : PageModel
    {
        private readonly IWaterParameterServices _waterParameterServices;

        public IndexModel(IWaterParameterServices waterParameterServices)
        {
            _waterParameterServices = waterParameterServices; // Khởi tạo biến dịch vụ
        }

        public IList<WaterParameter> WaterParameters { get; set; } = new List<WaterParameter>();
        public WaterParameter SelectedWaterParameter { get; set; }
        public int? SelectedPondId { get; set; }

        public async Task OnGetAsync(int? pondId)
        {
            WaterParameters = await _waterParameterServices.GetAllWaterParametersAsync();

            if (pondId.HasValue)
            {
                SelectedPondId = pondId;
                try
                {
                    SelectedWaterParameter = await _waterParameterServices.GetSuggestedWaterParametersAsync(pondId.Value);
                }
                catch (KeyNotFoundException)
                {
                    SelectedWaterParameter = null;
                }
            }
        }

        // Thêm phương thức để lấy gợi ý
        public string GetWaterParameterSuggestion(WaterParameter parameter)
        {
            return _waterParameterServices.GetWaterParameterSuggestion(parameter);
        }
    }
}
