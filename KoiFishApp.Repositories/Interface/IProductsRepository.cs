using KoiCare.Repositories.Enteteis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCare.Repositories.Interfaces
{
    public interface IProducts
    {
        Task<List<Product>> GetProducts();
        Task<List<GioHang>> GetGioHangs();
    }
}
