using Microsoft.EntityFrameworkCore;

namespace Commerce.Models
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options)
            :base(options)
            {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Client);

            modelBuilder.Entity<ProductOrder>()
                .HasKey(po => new { po.ProductId, po.OrderId });
            modelBuilder.Entity<ProductOrder>()
                .HasOne(po => po.Product)
                .WithMany(p => p.ProductOrders)
                .HasForeignKey(po => po.ProductId);
            modelBuilder.Entity<ProductOrder>()
                .HasOne(po => po.Order)
                .WithMany(o => o.ProductOrders)
                .HasForeignKey(po => po.OrderId);
            modelBuilder.Entity<Order>()
                .HasKey(o => o.OrderId);

         
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Client> Clients { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }


        public DbSet<ProductOrder> ProductOrders { get; set; }


    }
}