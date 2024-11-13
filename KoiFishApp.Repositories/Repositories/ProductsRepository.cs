using KoiCare.Repositories.Entities;
using KoiCare.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCare.Repositories.Repositories
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
            List<Product> products = await _dbcontext.Products.ToListAsync();
            return products;
        }

        public async Task<List<GioHang>> GetGioHangs()
        {
            List<GioHang> products = await _dbcontext.GioHangs.ToListAsync();
            
            return products;
        }

    }
}
