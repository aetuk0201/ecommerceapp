using Core.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItem");
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.OwnsOne(i => i.ItemOrdered, io =>
            {
                io.WithOwner();
                io.Property(i => i.ProductOrderedId).HasColumnName("ProductOrderedId");
                io.Property(i => i.ProductName).HasColumnName("ProductName");
                io.Property(i => i.ImageUrl).HasColumnName("ImageUrl");
            });
            builder.Property(i => i.Price).HasColumnType("decimal(18,2)");
        }
    }
}