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
        public void CreateProduct(Product product)
        {
            if (product == null) 
            {
                throw new ArgumentNullException(nameof(product));
            }
            _contex.Products.Add(product);
        }

        public void DeleteProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            _contex.Products.Remove(product);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _contex.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _contex.Products.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_contex.SaveChanges() >= 0);
        }

        public void UpdateProduct(Product product)
        {
            
        }
    }
}
