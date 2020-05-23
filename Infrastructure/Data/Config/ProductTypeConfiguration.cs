using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.ToTable("ProductType");
            //builder.HasKey(p => p.Id).IsClustered(true).HasName("PrimaryKey_Id");
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).HasColumnType("varchar(200)").IsRequired();
            builder.HasIndex(i => new
            {
                i.Name
            })
            .IsUnique()
            .IsClustered(false)
            .HasName("IX_ProductTypeName");

            builder.HasData(
                new ProductType()
                {
                    Id = 1,
                    Name = "Self Development"
                },
                new ProductType()
                {
                    Id = 2,
                    Name = "Mathematics"
                },
                new ProductType()
                {
                    Id = 3,
                    Name = "Soccer Ball"
                },
                new ProductType()
                {
                    Id = 4,
                    Name = "NFL Ball"
                }
            );
        }
    }
}