using KoiFishApp.Repositories.Entities;
using KoiFishApp.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFishApp.Repositories.Repositories
{
       public class KoiFishRepositories : IKoiFishRepositories
    {
        private readonly QlcktnContext _DbContext;
        public KoiFishRepositories(QlcktnContext DbContext)
        {
            _DbContext = DbContext;
        }
       public async Task<List<KoiFish>> GetAllKoiFish()
       {
            // Sử dụng Include để lấy thông tin của bảng liên quan (Pond)
            return await _DbContext.KoiFishes.Include(k => k.Pond).ToListAsync();
       }
       public async Task AddKoiFish(KoiFish koiFish)
       {
           // Thêm cá Koi vào DbSet
           await _DbContext.KoiFishes.AddAsync(koiFish);
           // Lưu các thay đổi vào cơ sở dữ liệu
           await _DbContext.SaveChangesAsync();
       }
       public void DeleteKoiFish(KoiFish koiFish)  // Đảm bảo phương thức này nhận KoiFish
       {
           _DbContext.KoiFishes.Remove(koiFish);
       }
       // Triển khai GetKoiFishByIdAsync
       public async Task<KoiFish?> GetKoiFishByIdAsync(int id)
       {
           return await _DbContext.KoiFishes.FirstOrDefaultAsync(k => k.KoiId == id);
       }
       public async Task SaveChangesAsync()  // Triển khai phương thức SaveChangesAsync
       {
           await _DbContext.SaveChangesAsync();
       }
       public void UpdateKoiFish(KoiFish koiFish)
       {
           _DbContext.KoiFishes.Update(koiFish);
       }
       
       public async Task<bool> KoiFishExistsAsync(int id)
       {
           return await _DbContext.KoiFishes.AnyAsync(e => e.KoiId == id);
       }

       public async Task<List<Pond>> GetAllPondsAsync()
       {
           return await _DbContext.Ponds.ToListAsync();
       }             
    }
}
