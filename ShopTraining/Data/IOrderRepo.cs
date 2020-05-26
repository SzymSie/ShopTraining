using ShopTraining.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopTraining.Data
{
   public interface IOrderRepo
    {
        Task<bool> SaveChangesAsync();

        Task CreateOrderAsync(Order order);
        Task UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(Order order);
        Task<Order> GetProductByIdAsync(int id);

        Task<IEnumerable<Order>> GetOrdersByCustomerId(int customerId);
        Task<Order> GetProductFromOrderByIdAsync(int iproductId, int customerId);
        Task AddProductToOrderAsync(Order order);
        Task UpdateProductQuantityInOrderAsync(Order order);
        Task DeleteProductFromOrderAsync(Order order);
    }
}
