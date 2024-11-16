using KoiFishApp.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFishApp.Services.Interfaces
{
    public interface IProductsService
    {
        Task<List<Product>> GetCurrentListItems();
        Task<List<GioHang>> GetGioHangHienTai();

        bool AddProduct(Product product);

        bool AddGioHang(GioHang product);

        bool RemoveProduct(int productId);

        bool RemoveGioHang(int productId);

        Task<Product> GetProductById(int productId);

        Task<GioHang> FindProductInGioHangById(int productId);
    }
}
