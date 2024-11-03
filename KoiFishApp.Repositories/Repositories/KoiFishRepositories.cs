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
    }
}
