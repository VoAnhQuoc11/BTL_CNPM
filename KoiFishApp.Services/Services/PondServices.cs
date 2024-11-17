using KoiFishApp.Repositories.Entities;
using KoiFishApp.Services.Interfaces;
using KoiFishApp.Repositories.Interfaces;

namespace KoiFishApp.Services.Services
{
    public class PondServices : IPondServices
    {
        private readonly IPondRepositories _repositories;
        private readonly IWaterParameterServices _waterParameterServices;
        private readonly IKoiFishServices _koiFishServices;


        // Constructor để inject IPondRepositories vào
        public PondServices(IPondRepositories repositories, IWaterParameterServices waterParameterServices, IKoiFishServices koiFishServices)
        {
            _repositories = repositories;
            _waterParameterServices = waterParameterServices;
            _koiFishServices = koiFishServices;
        }

        // Thêm một Pond mới vào cơ sở dữ liệu
        public async Task AddAsync(Pond pond)
        {
            await _repositories.Add(pond);
            await _repositories.SaveChangesAsync();
            await _waterParameterServices.AddWaterParameterForPondIdAsync(pond.PondId);
        }

        // Kiểm tra xem Pond có tồn tại không
        public async Task<bool> isExistsAsync(int id)
        {
            return await _repositories.isExistsAsync(id);
        }

        // Xóa Pond và các thông số nước liên quan
        public async Task DeleteAsync(int id)
        {
            // Kiểm tra xem có cá Koi nào đang sử dụng PondId này không
            var koiFishes = await _koiFishServices.KoiFish();
            if (koiFishes.Any(k => k.PondId == id))
            {
                throw new InvalidOperationException("Không thể xóa hồ vì vẫn còn cá trong hồ.");
            }

            var pond = await _repositories.GetByIdAsync(id);
            if (pond == null)
            {
                throw new InvalidOperationException("The pond does not exist or has already been deleted.");
            }

            // Xóa tất cả các thông số nước liên quan trước khi xóa Pond
            await _waterParameterServices.DeleteWaterParameterAsync(id);

            // Xóa Pond sau khi đã xóa thông số nước
            await _repositories.Delete(id);
        }

        // Lấy tất cả các Pond từ cơ sở dữ liệu
        public async Task<List<Pond>> GetAllPondsAsync()
        {
            return await _repositories.GetAllPondsAsync();
        }

        // Lấy một Pond theo ID
        public async Task<Pond?> GetByIdAsync(int id)
        {
            return await _repositories.GetByIdAsync(id);
        }

        // Cập nhật thông tin của Pond
        public async Task UpdateAsync(Pond pond)
        {
            await _repositories.Update(pond);
            await _repositories.SaveChangesAsync();
        }
    }
}