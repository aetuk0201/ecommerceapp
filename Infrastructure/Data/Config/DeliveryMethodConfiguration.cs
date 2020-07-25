using Core.Entities.Orders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Config
{
    public class DeliveryMethodConfiguration : IEntityTypeConfiguration<DeliveryMethod>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<DeliveryMethod> builder)
        {
            builder.ToTable("DeliveryMethod");
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(d => d.Price).HasColumnType("decimal(18,2)");
            builder.Property(d => d.DeliveryTime).HasColumnType("varchar(50)");
            builder.Property(d => d.Description).HasColumnType("varchar(500)");
            builder.HasIndex(i => new
            {
                i.ShortName
            })
            .IsUnique()
            .IsClustered(false)
            .HasName("IX_ShortName");

            builder.HasData(
                new DeliveryMethod()
                {
                    Id = 1,
                    ShortName = "UPS1",
                    Description = "Fastest delivery time",
                    DeliveryTime = "1-2 Days",
                    Price = 20m
                },
                new DeliveryMethod()
                {
                    Id = 2,
                    ShortName = "UPS2",
                    Description = "Get it within 5 days",
                    DeliveryTime = "2-5 Days",
                    Price = 5m
                },
                new DeliveryMethod()
                {
                    Id = 3,
                    ShortName = "UPS3",
                    Description = "Slower but cheap",
                    DeliveryTime = "5-10 Days",
                    Price = 2m
                },
                new DeliveryMethod()
                {
                    Id = 4,
                    ShortName = "UPS4",
                    Description = "Free! You get what you pay for",
                    DeliveryTime = "1-2 Weeks",
                    Price = 0m
                }

            );
        }
    }
}