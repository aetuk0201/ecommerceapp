using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {

        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Department");
            //builder.HasKey(p => p.Id).IsClustered(true).HasName("PrimaryKey_Id");
            builder.Property(d => d.Id).ValueGeneratedOnAdd();
            builder.Property(d => d.Name).HasColumnType("varchar(200)").IsRequired();
            builder.Property(d => d.Description).HasColumnType("varchar(500)");
            builder.HasIndex(i => new
            {
                i.Name
            })
            .IsUnique()
            .IsClustered(false)
            .HasName("IX_DepartmentName");

            builder.HasData(
                new Department()
                {
                    Id = 1,
                    Name = "Books",
                    Description = "Books"
                },
                new Department()
                {
                    Id = 2,
                    Name = "Sports",
                    Description = "Sports"
                }
            );
        }
    }
}