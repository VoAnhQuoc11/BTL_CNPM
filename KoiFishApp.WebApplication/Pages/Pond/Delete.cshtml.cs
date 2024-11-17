using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiFishApp.Services.Interfaces;
using KoiFishApp.Repositories.Entities;
namespace KoiFishApp.Pages.Pond
{
    public class DeleteModel : PageModel
    {
        private readonly IPondServices _pondServices;
        private readonly IKoiFishServices _koiFishServices;

        public DeleteModel(IPondServices pondServices, IKoiFishServices koiFishServices)
        {
            _pondServices = pondServices;
            _koiFishServices = koiFishServices;
        }

        [BindProperty]
        public KoiFishApp.Repositories.Entities.Pond Pond { get; set; } = new KoiFishApp.Repositories.Entities.Pond();

        public List<KoiFish> KoiFishInPond { get; set; } = new List<KoiFish>();

        public bool IsDeleteAttempted { get; set; } = false;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Pond = await _pondServices.GetByIdAsync(id);

            if (Pond == null)
            {
                return NotFound();
            }

            // Lấy danh sách cá Koi đang sử dụng PondId này
            KoiFishInPond = await _koiFishServices.KoiFish();
            KoiFishInPond = KoiFishInPond.Where(k => k.PondId == id).ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            IsDeleteAttempted = true;

            try
            {
                await _pondServices.DeleteAsync(id);
                return RedirectToPage("./Index");
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, "Không thể xóa hồ này vì vẫn còn cá trong hồ.");
                return Page();
            }
        }
    }
}