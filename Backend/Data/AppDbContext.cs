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
                .ToTable("Account")
                .HasOne<Account>()
                .WithOne()
                .OnDelete(deleteBehavior: DeleteBehavior.SetNull);

            modelBuilder.Entity<User>()
                .ToTable("User")
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(u=>u.ID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Address>()
                .ToTable("Address")
                .HasOne<Address>()
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Cart>()
                .ToTable("Cart");

            modelBuilder.Entity<Category>()
                .ToTable("Category");

            modelBuilder.Entity<Product>()
                .ToTable("Product")
                .HasOne<Product>()
                .WithMany()
                .HasForeignKey(u => u.ID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductOption>()
                .ToTable("ProductOption")
                .HasOne<ProductOption>()
                .WithMany()
                .HasForeignKey(u => u.ID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Order>().ToTable("Order")
                .HasOne<Order>()
                .WithMany()
                .HasForeignKey(u => u.ID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<OrderTracking>()
                .ToTable("OrderTracking")
                .HasOne<OrderTracking>()
                .WithMany()
                .HasForeignKey(u => u.ID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Payment>()
                .ToTable("Payment")
                .HasOne<Payment>()
                .WithMany()
                .HasForeignKey(u => u.ID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<PaymentMethod>()
                .ToTable("PaymentMethod")
                .HasOne<PaymentMethod>()
                .WithMany()
                .HasForeignKey(u => u.ID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
