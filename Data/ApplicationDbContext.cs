using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShippingSystem.Models;

namespace ShippingSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }
        public DbSet<ShippingType> ShippingType { get; set; }

    }
}