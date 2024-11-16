using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoiFishApp.Repositories.Entities;
using KoiFishApp.Repositories.Interfaces;
using KoiFishApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KoiFishAppServices.Services
{
    public class WaterParameterServices : IWaterParameterServices
    {
        private readonly IWaterParameterRepositories _waterParametersRepositories;

        public WaterParameterServices(IWaterParameterRepositories waterParametersRepositories)
        {
            _waterParametersRepositories = waterParametersRepositories;
        }

        public Task<List<WaterParameter>> GetAllWaterParametersAsync()
        {
            return _waterParametersRepositories.GetAllWaterParametersAsync();
        }

        public async Task<WaterParameter> GetWaterParameterByIdAsync(int id)
        {
            return await _waterParametersRepositories.GetWaterParameterByIdAsync(id);
        }

        public async Task<List<WaterParameter>> GetWaterParametersByPondIdAsync(int pondId)
        {
            return await _waterParametersRepositories.GetWaterParametersByPondIdAsync(pondId);
        }

        public async Task AddWaterParameterAsync(WaterParameter waterParameter)
        {
            await _waterParametersRepositories.AddWaterParameterAsync(waterParameter);
        }

        public async Task UpdateWaterParameterAsync(WaterParameter waterParameter)
        {
            await _waterParametersRepositories.UpdateWaterParameterAsync(waterParameter);
        }

        public async Task DeleteWaterParameterAsync(int id)
        {
            await _waterParametersRepositories.DeleteWaterParameterAsync(id);
        }

        public async Task AddWaterParameterForPondIdAsync(int pondId)
        {
            // Tạo một đối tượng WaterParameter mới với các giá trị mặc định
            var waterParameter = new WaterParameter
            {
                Id = pondId,
                Temperature = 22.0,  // Giá trị nhiệt độ mặc định
                Salinity = 0.1,      // Giá trị độ mặn mặc định
                Ph = 7.5,            // Giá trị pH mặc định
                O2 = 8.0,            // Giá trị O2 mặc định
                No2 = 0.0,           // Giá trị NO2 mặc định
                No3 = 25.0,          // Giá trị NO3 mặc định
                Po4 = 1.0,           // Giá trị PO4 mặc định
                MeasurementDate = DateTime.Now  // Ngày đo
            };

            // Thêm WaterParameter vào cơ sở dữ liệu
            await _waterParametersRepositories.AddWaterParameterAsync(waterParameter);
        }
        public async Task<WaterParameter> GetSuggestedWaterParametersAsync(int pondId)
        {
            // Lấy thông số nước từ repository dựa trên pondId
            var waterParameter = await _waterParametersRepositories.GetWaterParameterByIdAsync(pondId);

            // Kiểm tra nếu không tìm thấy, ném ngoại lệ
            if (waterParameter == null)
            {
                throw new KeyNotFoundException($"No water parameters found for Pond ID {pondId}");
            }

            // Trả về đối tượng WaterParameter
            return waterParameter;
        }
        public class WaterParameterStandard
        {
            public const double IdealTemperature = 22.0; // Nhiệt độ lý tưởng
            public const double IdealSalinity = 0.2; // Độ mặn lý tưởng
            public const double IdealPh = 7.5; // pH lý tưởng
            public const double IdealO2 = 8.0; // O2 lý tưởng
            public const double IdealNo2 = 0.0; // NO2 lý tưởng
            public const double IdealNo3 = 25.0; // NO3 lý tưởng
            public const double IdealPo4 = 1.0; // PO4 lý tưởng
        }

        public string GetWaterParameterSuggestion(WaterParameter parameter)
        {
            var suggestions = new List<string>();

            // Kiểm tra Nhiệt độ
            if (parameter.Temperature.HasValue) // Kiểm tra nếu có giá trị
            {
                double temperatureValue = parameter.Temperature.Value; // Lấy giá trị double
                if (temperatureValue < WaterParameterStandard.IdealTemperature)
                {
                    double increaseAmount = WaterParameterStandard.IdealTemperature - temperatureValue;
                    suggestions.Add($"Nhiệt độ ({temperatureValue}°C) thấp hơn tiêu chuẩn ({WaterParameterStandard.IdealTemperature}°C), hãy tăng nhiệt độ thêm {increaseAmount}°C.");
                }
                else if (temperatureValue > WaterParameterStandard.IdealTemperature)
                {
                    double decreaseAmount = temperatureValue - WaterParameterStandard.IdealTemperature;
                    suggestions.Add($"Nhiệt độ ({temperatureValue}°C) cao hơn tiêu chuẩn ({WaterParameterStandard.IdealTemperature}°C), hãy giảm nhiệt độ thêm {decreaseAmount}°C.");
                }
                else
                {
                    suggestions.Add($"Nhiệt độ ({temperatureValue}°C) đã đạt tiêu chuẩn.");
                }
            }
            else
            {
                suggestions.Add("Nhiệt độ chưa được đo.");
            }

            // Kiểm tra Độ mặn
            if (parameter.Salinity.HasValue)
            {
                double salinityValue = parameter.Salinity.Value;
                if (salinityValue < WaterParameterStandard.IdealSalinity)
                {
                    double increaseAmount = WaterParameterStandard.IdealSalinity - salinityValue;
                    suggestions.Add($"Độ mặn ({salinityValue} ppt) thấp hơn tiêu chuẩn ({WaterParameterStandard.IdealSalinity} ppt), hãy tăng độ mặn thêm {increaseAmount} ppt.");
                }
                else if (salinityValue > WaterParameterStandard.IdealSalinity)
                {
                    double decreaseAmount = salinityValue - WaterParameterStandard.IdealSalinity;
                    suggestions.Add($"Độ mặn ({salinityValue} ppt) cao hơn tiêu chuẩn ({WaterParameterStandard.IdealSalinity} ppt), hãy giảm độ mặn thêm {decreaseAmount} ppt.");
                }
                else
                {
                    suggestions.Add($"Độ mặn ({salinityValue} ppt) đã đạt tiêu chuẩn.");
                }
            }
            else
            {
                suggestions.Add("Độ mặn chưa được đo.");
            }

            // Kiểm tra pH
            if (parameter.Ph.HasValue)
            {
                double phValue = parameter.Ph.Value;
                if (phValue < WaterParameterStandard.IdealPh)
                {
                    suggestions.Add($"pH ({phValue}) thấp hơn tiêu chuẩn ({WaterParameterStandard.IdealPh}), hãy tăng pH.");
                }
                else if (phValue > WaterParameterStandard.IdealPh)
                {
                    suggestions.Add($"pH ({phValue}) cao hơn tiêu chuẩn ({WaterParameterStandard.IdealPh}), hãy giảm pH.");
                }
                else
                {
                    suggestions.Add($"pH ({phValue}) đã đạt tiêu chuẩn.");
                }
            }
            else
            {
                suggestions.Add("pH chưa được đo.");
            }

            // Kiểm tra O2
            if (parameter.O2.HasValue)
            {
                double o2Value = parameter.O2.Value;
                if (o2Value < WaterParameterStandard.IdealO2)
                {
                    suggestions.Add($"Oxy ({o2Value} mg/L) thấp hơn tiêu chuẩn ({WaterParameterStandard.IdealO2} mg/L), hãy tăng lượng oxy.");
                }
                else if (o2Value > WaterParameterStandard.IdealO2)
                {
                    suggestions.Add($"Oxy ({o2Value} mg/L) cao hơn tiêu chuẩn ({WaterParameterStandard.IdealO2} mg/L), hãy giảm lượng oxy.");
                }
                else
                {
                    suggestions.Add($"Oxy ({o2Value} mg/L) đã đạt tiêu chuẩn.");
                }
            }
            else
            {
                suggestions.Add("Oxy chưa được đo.");
            }

            // Kiểm tra NO2
            if (parameter.No2.HasValue)
            {
                double no2Value = parameter.No2.Value;
                if (no2Value < WaterParameterStandard.IdealNo2)
                {
                    suggestions.Add($"NO2 ({no2Value} mg/L) thấp hơn tiêu chuẩn ({WaterParameterStandard.IdealNo2} mg/L), hãy tăng NO2.");
                }
                else if (no2Value > WaterParameterStandard.IdealNo2)
                {
                    suggestions.Add($"NO2 ({no2Value} mg/L) cao hơn tiêu chuẩn ({WaterParameterStandard.IdealNo2} mg/L), hãy giảm NO2.");
                }
                else
                {
                    suggestions.Add($"NO2 ({no2Value} mg/L) đã đạt tiêu chuẩn.");
                }
            }
            else
            {
                suggestions.Add("NO2 chưa được đo.");
            }

            // Kiểm tra NO3
            if (parameter.No3.HasValue)
            {
                double no3Value = parameter.No3.Value;
                if (no3Value < WaterParameterStandard.IdealNo3)
                {
                    suggestions.Add($"NO3 ({no3Value} mg/L) thấp hơn tiêu chuẩn ({WaterParameterStandard.IdealNo3} mg/L), hãy tăng NO3.");
                }
                else if (no3Value > WaterParameterStandard.IdealNo3)
                {
                    suggestions.Add($"NO3 ({no3Value} mg/L) cao hơn tiêu chuẩn ({WaterParameterStandard.IdealNo3} mg/L), hãy giảm NO3.");
                }
                else
                {
                    suggestions.Add($"NO3 ({no3Value} mg/L) đã đạt tiêu chuẩn.");
                }
            }
            else
            {
                suggestions.Add("NO3 chưa được đo.");
            }

            // Kiểm tra PO4
            if (parameter.Po4.HasValue)
            {
                double po4Value = parameter.Po4.Value;
                if (po4Value < WaterParameterStandard.IdealPo4)
                {
                    suggestions.Add($"PO4 ({po4Value} mg/L) thấp hơn tiêu chuẩn ({WaterParameterStandard.IdealPo4} mg/L), hãy tăng PO4.");
                }
                else if (po4Value > WaterParameterStandard.IdealPo4)
                {
                    suggestions.Add($"PO4 ({po4Value} mg/L) cao hơn tiêu chuẩn ({WaterParameterStandard.IdealPo4} mg/L), hãy giảm PO4.");
                }
                else
                {
                    suggestions.Add($"PO4 ({po4Value} mg/L) đã đạt tiêu chuẩn.");
                }
            }
            else
            {
                suggestions.Add("PO4 chưa được đo.");
            }

            // Trả về danh sách gợi ý
            return string.Join("<br />", suggestions);
        }


    }
}
    