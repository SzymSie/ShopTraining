using Microsoft.EntityFrameworkCore;
using ShopTraining.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopTraining.Data
{
    public class SqlProductRepo : IProductRepo
    {
        private readonly ProductContext _contex;

        public SqlProductRepo(ProductContext context) 
        {
            _contex = context;
        }
        public async void CreateProductAsync(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            await _contex.Products.AddAsync(product);
        }

        public async void DeleteProductAsync(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            _contex.Products.Remove(product);
            await _contex.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _contex.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _contex.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _contex.SaveChangesAsync() >= 0);
        }

        public async void UpdateProductAsync(Product product)
        {
            
        }
    }
}
