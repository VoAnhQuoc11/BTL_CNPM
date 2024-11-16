using KoiFishApp.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFishApp.Repositories.Interfaces
{
    public interface IProducts
    {
        Task<List<Product>> GetProducts();
        Task<List<GioHang>> GetGioHangs();

        bool AddProduct(Product product);

        bool AddGioHang(GioHang product);
        bool RemoveProduct(int productId);

        bool RemoveGioHang(int productId);

        Task<Product> FindProductById(int productId);

        Task<GioHang> FindProductInGioHangById(int productId);
       
    }
}
