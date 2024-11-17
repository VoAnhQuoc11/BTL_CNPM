using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFishApp.Repositories.Entities;
using KoiFishApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KoiFishApp.Repositories.Repositories
{
    public class PondRepositories : IPondRepositories
    {
        private readonly QlcktnContext _DbContext;

        // Constructor để inject DbContext vào
        public PondRepositories(QlcktnContext DbContext)
        {
            _DbContext = DbContext;
        }

        // Thêm một Pond mới vào cơ sở dữ liệu
        public async Task Add(Pond pond)
        {
            await _DbContext.Ponds.AddAsync(pond); // Thêm Pond vào DbContext mà không chỉ định giá trị cho PondID
            await _DbContext.SaveChangesAsync(); // Lưu thay đổi vào cơ sở dữ liệu
        }


        public async Task<bool> isExistsAsync(int id)
        {
            return await _DbContext.Ponds.AnyAsync(e => e.PondId == id);
        }

        // Xóa một Pond khỏi cơ sở dữ liệu
        public async Task Delete(int id)
        {
            var pond = await _DbContext.Ponds.FindAsync(id);
            if (pond == null)
            {
                throw new InvalidOperationException("The pond does not exist or has already been deleted.");
            }

            _DbContext.Ponds.Remove(pond);
            await _DbContext.SaveChangesAsync();
        }

        // Lấy tất cả các Pond từ cơ sở dữ liệu
        public async Task<List<Pond>> GetAll()
        {
            return await _DbContext.Ponds.ToListAsync();  // Lấy danh sách tất cả các Pond
        }

        // Lấy tất cả các Pond (dành cho async)
        public async Task<List<Pond>> GetAllPondsAsync()
        {
            return await _DbContext.Ponds.ToListAsync();  // Lấy danh sách tất cả các Pond
        }

        // Lấy một Pond theo ID từ cơ sở dữ liệu
        public async Task<Pond?> GetByIdAsync(int id)
        {
            return await _DbContext.Ponds.FirstOrDefaultAsync(p => p.PondId == id);  // Tìm Pond theo PondId
        }

        // Kiểm tra xem Pond có tồn tại trong cơ sở dữ liệu không
        public async Task<bool> IsExistsAsync(int id)
        {
            return await _DbContext.Ponds.AnyAsync(p => p.PondId == id);  // Kiểm tra xem Pond có tồn tại với id này không
        }

        // Lưu các thay đổi vào cơ sở dữ liệu
        public async Task SaveChangesAsync()
        {
            await _DbContext.SaveChangesAsync();  // Lưu các thay đổi vào cơ sở dữ liệu
        }

        // Cập nhật thông tin của một Pond trong cơ sở dữ liệu
        public async Task Update(Pond pond)
        {
            _DbContext.Ponds.Update(pond);  // Cập nhật Pond trong DbSet
            await _DbContext.SaveChangesAsync();  // Lưu thay đổi vào cơ sở dữ liệu
        }


    }
}
