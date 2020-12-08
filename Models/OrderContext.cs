using Microsoft.EntityFrameworkCore;
using OrdemExample.Models;

namespace Commerce.Models
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options)
            :base(options)
            {}
        public DbSet<Order> Orders { get; set; }
        public DbSet<Client> Clients { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }


    }
}