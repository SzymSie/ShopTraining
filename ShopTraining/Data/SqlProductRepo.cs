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
        private readonly AppContext _context;

        public SqlProductRepo(AppContext context) 
        {
            _context = context;
        }
        public async Task CreateProductAsync(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            await _context.Products.AddAsync(product);
        }

        public async Task DeleteProductAsync(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        public async Task UpdateProductAsync(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
