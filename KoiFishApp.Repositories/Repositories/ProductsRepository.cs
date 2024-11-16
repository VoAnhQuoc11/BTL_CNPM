using KoiFishApp.Repositories.Interfaces;
using KoiFishApp.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFishApp.Repositories.Repositories
{
    public class ProductsRepository : IProducts
    {

        private readonly QlcktnContext _dbcontext;
        public ProductsRepository(QlcktnContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<List<Product>> GetProducts()
        {
            return await _dbcontext.Products.ToListAsync();
        }

        public async Task<List<GioHang>> GetGioHangs()
        {
            return await _dbcontext.GioHangs.ToListAsync();

        }

        public bool AddProduct(Product product)
        {
            try
            {
                _dbcontext.Products.Add(product);
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
                var objDel = _dbcontext.Products.Where(p => p.ProductId.Equals(productId)).FirstOrDefault();
                if (objDel != null)
                {
                    _dbcontext.Products.Remove(objDel);
                    _dbcontext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            };
        }
        public async Task<Product> FindProductById(int productId)
        {
            return await _dbcontext.Products.FindAsync(productId);
        }

        public async Task<GioHang> FindProductInGioHangById(int productId)
        {
            return await _dbcontext.GioHangs.FindAsync(productId);
        }

        public bool AddGioHang(GioHang product)
        {
            try
            {
                _dbcontext.GioHangs.Add(product);
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
                var objDel = _dbcontext.GioHangs.Where(p => p.ProductId.Equals(productId)).FirstOrDefault();
                if (objDel != null)
                {
                    _dbcontext.GioHangs.Remove(objDel);
                    _dbcontext.SaveChanges();
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
