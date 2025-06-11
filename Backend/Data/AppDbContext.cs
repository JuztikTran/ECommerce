using BusinessObjetcs.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Account> Accounts{ get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<Address> Addresses{ get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Cart> Carts{ get; set; }
        public DbSet<Product> Products{ get; set; }
        public DbSet<ProductOption> Options{ get; set; }
        public DbSet<Order> Orders{ get; set; }
        public DbSet<OrderTracking> Trackings{ get; set; }
        public DbSet<Payment> Payments{ get; set; }
        public DbSet<PaymentMethod> Methods{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .ToTable("Account");

            modelBuilder.Entity<User>()
                .ToTable("User");

            modelBuilder.Entity<Address>()
                .ToTable("Address");

            modelBuilder.Entity<Cart>()
                .ToTable("Cart");

            modelBuilder.Entity<Category>()
                .ToTable("Category");

            modelBuilder.Entity<Product>()
                .ToTable("Product");

            modelBuilder.Entity<ProductOption>()
                .ToTable("ProductOption");

            modelBuilder.Entity<Order>()
                .ToTable("Order");

            modelBuilder.Entity<OrderTracking>()
                .ToTable("OrderTracking");

            modelBuilder.Entity<Payment>()
                .ToTable("Payment");

            modelBuilder.Entity<PaymentMethod>()
                .ToTable("PaymentMethod");
        }
    }
}
