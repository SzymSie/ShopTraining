using Microsoft.EntityFrameworkCore;
using ShopTraining.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopTraining.Data
{
    public class SqlOrderRepo : IOrderRepo
    {
        private readonly AppContext _context;

        public SqlOrderRepo(AppContext context)
        {
            _context = context;
        }

        public async Task<Order> GetProductByIdAsync(int id)
        {
            return await _context.Orders.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task CreateOrderAsync(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }
            await _context.Orders.AddAsync(order);
        }
        public async Task UpdateOrderAsync(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }





        public async Task AddProductToOrderAsync(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }
            await _context.Orders.AddAsync(order);
        }

       
        public async Task DeleteProductFromOrderAsync(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomerId(int customerId)
        {
           
            return await _context.Orders.Where(p=>p.CustomerId == customerId).ToListAsync();
        }

        public async Task<Order> GetProductFromOrderByIdAsync(int productId, int customerId)
        {
            return await _context.Orders.FirstOrDefaultAsync(p => p.ProductId == productId 
            && p.CustomerId ==customerId);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        public async Task UpdateProductQuantityInOrderAsync(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }

    }
}
