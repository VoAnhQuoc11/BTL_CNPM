using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiFishApp.Services.Interfaces;
using KoiFishApp.Repositories.Entities;
using KoiFishApp.Services.Interfaces;

namespace KoiFishApp.Pages.Pond
{
    public class IndexModel : PageModel
    {
        private readonly IPondServices _pondServices;

        public IndexModel(IPondServices pondServices)
        {
            _pondServices = pondServices;
        }

        public IList<KoiFishApp.Repositories.Entities.Pond> Ponds { get; set; } = new List<KoiFishApp.Repositories.Entities.Pond>();
        public Dictionary<int, double> PondSaltAmounts { get; set; } = new Dictionary<int, double>(); // Lượng muối theo từng ao

        public async Task OnGetAsync()
        {
            Ponds = await _pondServices.GetAllPondsAsync();

            // Tính lượng muối cho từng ao dựa trên thể tích và lưu vào từ điển
            foreach (var pond in Ponds)
            {
                PondSaltAmounts[pond.PondId] = CalculateSaltAmount(pond.Volume ?? 0);
            }
        }

        private double CalculateSaltAmount(double volume)
        {
            double saltConcentration = 0.03; // Giả sử lượng muối là 3% thể tích nước
            return volume * saltConcentration;
        }
    }
}