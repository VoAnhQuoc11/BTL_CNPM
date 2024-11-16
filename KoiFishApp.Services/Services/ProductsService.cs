using KoiFishApp.Repositories.Interfaces;
using KoiFishApp.Repositories.Entities;

using KoiFishApp.Services.Interfaces;

namespace KoiFishApp.Services.Services
{
    public class ProductsService : IProductsService
    {

        private IProducts _productRepository;

        public ProductsService(IProducts productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetCurrentListItems()
        {
            return await _productRepository.GetProducts();

        }

        public async Task<List<GioHang>> GetGioHangHienTai()
        {
            return await _productRepository.GetGioHangs();
        }

        public bool AddProduct(Product product)
        {
            try
            {
                _productRepository.AddProduct(product);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool RemoveProduct(int productId)
        {
            try
            {
                if (_productRepository.RemoveProduct(productId) == true)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            };
        }

        public async Task<Product> GetProductById(int productId)
        {
            return await _productRepository.FindProductById(productId);
        }

        public async Task<GioHang> FindProductInGioHangById(int productId)
        {
            return await _productRepository.FindProductInGioHangById(productId);
        }

        public bool AddGioHang(GioHang product)
        {
            try
            {
                _productRepository.AddGioHang(product);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool RemoveGioHang(int productId)
        {
            try
            {
                if (_productRepository.RemoveGioHang(productId) == true)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            };
        }

    }
}
