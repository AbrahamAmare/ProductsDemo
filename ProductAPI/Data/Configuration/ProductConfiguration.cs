using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductAPI.Data.Models;

namespace ProductAPI.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Description)
                .HasColumnType("Text");

            builder.Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal")
                .HasPrecision(18, 2);
            builder.Property(p => p.CreateAt)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasDefaultValue(DateTime.UtcNow.Date);
            builder.Property(p => p.UpdateAt)
              .IsRequired()
              .HasColumnType("datetime2");

            // Seeding data for migration

            builder.HasData(
                 new Product
                 {
                     Id = Guid.NewGuid(),
                     Name = "Acer Predator Helios 300 PH315-54-760S",
                     Description = "Extreme Performance: Crush the competition with the " +
                                                                                                    "impressive power and speed of the 11th Generation " +
                                                                                                    "Intel Core i7-11800H processor, featuring 8 cores and 16 " +
                                                                                                    "threads to divide and conquer any task or run your most intensive games",
                     Price = 1375
                 },
                      new Product
                      {
                          Id = Guid.NewGuid(),
                          Name = "Alienware m15 R4 Gaming Laptop",
                          Description = "15.6-inch FHD (Full HD 1920 x 1080) 144Hz 7ms 300-nits 72% color gamut " +
                                                                                          "Generation Intel Core i7 - 10870H(8 - Core, 16MB Cache, " +
                                                                                          "up to 5.0GHz Turbo Frequency",
                          Price = 1745
                      }

            );
        }
    }
}
