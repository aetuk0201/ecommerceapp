using Core.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductOrderedConfiguration : IEntityTypeConfiguration<ProductOrdered>
    {
        public void Configure(EntityTypeBuilder<ProductOrdered> builder)
        {
            builder.ToTable("ProductOrdered");
            builder.Property(p => p.ProductOrderedId).ValueGeneratedNever();
            builder.Property(p => p.ProductName).HasColumnType("varchar(100)");
            builder.Property(p => p.ImageUrl).HasColumnType("varchar(200)");
        }
    }
}