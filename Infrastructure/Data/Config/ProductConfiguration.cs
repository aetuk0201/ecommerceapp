using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            //builder.HasKey(p => p.Id).IsClustered(true).HasName("PrimaryKey_Id");
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).HasColumnType("varchar(200)").IsRequired();
            builder.Property(p => p.Description).HasColumnType("varchar(2000)");
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
            //builder.Property(p => p.QtyInStock).HasMaxLength(20);
            //builder.Property(p => p.Quantity).HasMaxLength(20);
            //builder.Property(p => p.Rating).HasMaxLength(20);
            builder.Property(p => p.ImageName).HasColumnType("varchar(100)");
            builder.Property(p => p.ImagePath).HasColumnType("varchar(500)");
            builder.Property(p => p.ImageUrl).HasColumnType("varchar(500)");
            builder.Property(p => p.Code).HasColumnType("varchar(10)");
            builder.HasIndex(i => new
            {
                i.Name,
                i.DepartmentId,
                i.CategoryId,
                i.ProductTypeId
            })
            .IsUnique()
            .IsClustered(false)
            .HasName("IX_DeptCaegoryProdType");

            builder.HasData(
                new Product()
                {
                    Id = 1,
                    Name = "Ultimate Triumph",
                    Description = "The journey to self discovery",
                    DepartmentId = 1,
                    CategoryId = 1,
                    ProductTypeId = 1,
                    Price = 20m,
                    QtyInStock = 5,
                    ImageName = string.Empty,
                    ImagePath = string.Empty
                },
                new Product()
                {
                    Id = 2,
                    Name = "The Truth",
                    Description = "Finding truth in the midst of deception and supression",
                    DepartmentId = 1,
                    CategoryId = 1,
                    ProductTypeId = 1,
                    Price = 25m,
                    QtyInStock = 3,
                    ImageName = string.Empty,
                    ImagePath = string.Empty
                },
                new Product()
                {
                    Id = 3,
                    Name = "Higher Order Differential Equations",
                    Description = "Algorithms for solving equations",
                    DepartmentId = 1,
                    CategoryId = 2,
                    ProductTypeId = 2,
                    Price = 25m,
                    QtyInStock = 3,
                    ImageName = string.Empty,
                    ImagePath = string.Empty
                },
                new Product()
                {
                    Id = 4,
                    Name = "Dazzle Ball",
                    Description = "FIFA-approved size and weight",
                    DepartmentId = 2,
                    CategoryId = 3,
                    ProductTypeId = 3,
                    Price = 25m,
                    QtyInStock = 3,
                    ImageName = string.Empty,
                    ImagePath = string.Empty
                },
                new Product()
                {
                    Id = 5,
                    Name = "Spiralling Ball",
                    Description = "NFL-approved ball",
                    DepartmentId = 2,
                    CategoryId = 3,
                    ProductTypeId = 4,
                    Price = 15m,
                    QtyInStock = 3,
                    ImageName = string.Empty,
                    ImagePath = string.Empty
                }

            );
        }
    }
}