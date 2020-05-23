using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");
            //builder.HasKey(p => p.Id).IsClustered(true).HasName("PrimaryKey_Id");
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Name).HasColumnType("varchar(200)").IsRequired();
            builder.Property(c => c.Description).HasColumnType("varchar(500)");
            builder.HasIndex(i => new
            {
                i.Name
            })
            .IsUnique()
            .IsClustered(false)
            .HasName("IX_CategoryName");

            builder.HasData(
                new Category()
                {
                    Id = 1,
                    Name = "Self-Help",
                    Description = "Self Help"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Technical",
                    Description = "Anything technical"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Ball",
                    Description = "Ball"
                }
            );
        }
    }
}