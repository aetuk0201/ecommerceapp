using System;
using Core.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.CustomerEmail).HasColumnType("varchar(100)");
            builder.Property(d => d.OrderDate).HasColumnType("datetime2");
            builder.Property(d => d.Subtotal).HasColumnType("decimal(18,2)");
            builder.Property(d => d.Status).HasColumnType("varchar(50)");
            builder.Property("PaymentIntentId").HasColumnType("varchar(50)");
            builder.HasIndex(i => new
            {
                i.CustomerEmail
            })
            .IsUnique()
            .IsClustered(false)
            .HasName("IX_CustomerEmail");

            builder.Property(s => s.Status)
                .HasConversion(o => o.ToString(), o => (OrderStatus)Enum.Parse(typeof(OrderStatus), o));

            builder.HasMany(o => o.OrderItems).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}