using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiFishApp.Repositories.Entities;
using KoiFishApp.Services.Interfaces;

namespace KoiFishApp.WebApplication.Pages.CTKoiFish
{
    public class DetailsModel : PageModel
    {
        private readonly IKoiFishServices _services;
        private readonly IPondServices _pondServices;
        private readonly IKoiFishGrowthService _growthRecordServices;

        public DetailsModel(IKoiFishServices services, IPondServices pondServices, IKoiFishGrowthService growthRecordServices)
        {
            _services = services;
            _pondServices = pondServices;
            _growthRecordServices = growthRecordServices;
        }

        public KoiFish KoiFish { get; set; } = new KoiFish();
        public KoiFishApp.Repositories.Entities.Pond? Pond { get; set; }

        
        public List<KoiGrowth> GrowthRecords { get; set; } = new List<KoiGrowth>();
        // Khai báo FoodAmounts dưới dạng Dictionary để lưu giá trị FoodAmount cho từng GrowthRecord
        public Dictionary<int, decimal> FoodAmounts { get; set; } = new Dictionary<int, decimal>();
        [BindProperty]
        public KoiGrowth KoiGrowth { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Lấy thông tin cá Koi
            KoiFish = await _services.GetKoiFishByIdAsync((int)id);
            if (KoiFish == null)
            {
                return NotFound();
            }

            // Lấy danh sách bản ghi phát triển
            GrowthRecords = await _growthRecordServices.GetGrowthRecordsByKoiFishIdAsync((int)id) ?? new List<KoiGrowth>();

            // Duyệt qua các bản ghi phát triển để tính lượng thức ăn
            foreach (var record in GrowthRecords)
            {
                if (record.Weight.HasValue && record.Age.HasValue)
                {
                    // Gọi phương thức tính lượng thức ăn và lưu vào Dictionary
                    var foodAmount = _growthRecordServices.CalculateFoodAmount(
                        (decimal)record.Weight.Value,  // Chuyển đổi Weight từ double? sang decimal
                        record.Age.Value               // Chuyển đổi Age từ int? sang int
                    );
                    FoodAmounts[record.KoiGrowthId] = foodAmount;
                }
                else
                {
                    // Nếu Weight hoặc Age là null, gán giá trị mặc định
                    FoodAmounts[record.KoiGrowthId] = 0;
                }
            }

            // Lấy thông tin hồ cá
            if (KoiFish.PondId.HasValue)
            {
                Pond = await _pondServices.GetPondByIdAsync(KoiFish.PondId.Value);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int koiGrowthId, int koiId)
        {
            // Xóa bản ghi phát triển theo ID
            await _growthRecordServices.DeleteGrowthRecordAsync(koiGrowthId);

            // Chuyển hướng về trang Details với koiId hiện tại
            return RedirectToPage("./Details", new { id = koiId });
        }
    }
}
