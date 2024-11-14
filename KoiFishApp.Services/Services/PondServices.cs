using KoiFishApp.Repositories.Entities;
using KoiFishApp.Repositories.Interface;
using KoiFishApp.Repositories.Repositories;
using KoiFishApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoiFishApp.Services.Services
{
    public class PondServices : IPondServices
    {
        private readonly IPondRepositories _repositories;

        // Constructor để inject IPondRepositories vào
        public PondServices(IPondRepositories repositories)
        {
            _repositories = repositories;
        }

        // Thêm một Pond mới vào cơ sở dữ liệu
        public async Task AddAsync(Pond pond)
        {
            await _repositories.Add(pond);  // Dùng phương thức Add của repository
        }

        public async Task<bool> isExistsAsync(int id)
        {
            return await _repositories.isExistsAsync(id);  // Kiểm tra xem Pond có tồn tại không
        }

        // Xóa một Pond theo ID
        public async Task DeleteAsync(int id)
        {
            var pond = await _repositories.GetByIdAsync(id);  // Lấy Pond theo ID
            if (pond != null)
            {
                await _repositories.Delete(pond);  // Dùng phương thức Delete của repository
            }
        }

        // Lấy tất cả các Pond từ cơ sở dữ liệu
        public async Task<List<Pond>> GetAllPondsAsync()
        {
            return await _repositories.GetAllPondsAsync();  // Dùng phương thức GetAllPondsAsync của repository
        }

        // Lấy một Pond theo ID
        public async Task<Pond?> GetByIdAsync(int id)
        {
            return await _repositories.GetByIdAsync(id);  // Dùng phương thức GetByIdAsync của repository
        }

        // Kiểm tra xem Pond có tồn tại trong cơ sở dữ liệu không


        // Cập nhật thông tin của Pond
        public async Task UpdateAsync(Pond pond)
        {
            await _repositories.Update(pond); 
        }
    }
}
