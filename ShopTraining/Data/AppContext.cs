using Microsoft.EntityFrameworkCore;
using ShopTraining.Models;

namespace ShopTraining.Data
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> opt) : base(opt)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
