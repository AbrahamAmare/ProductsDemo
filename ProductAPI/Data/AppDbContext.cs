using Microsoft.EntityFrameworkCore;
using ProductAPI.Data.Configuration;
using ProductAPI.Data.Models;

namespace ProductAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasDefaultSchema("product_db");

            // Entity Type Configurations

            builder.ApplyConfiguration(new ProductConfiguration());            
        }
    }
}
