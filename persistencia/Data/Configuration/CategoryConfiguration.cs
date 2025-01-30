using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories", "Production");
            builder.HasIndex(e => e.categoryname, "categoryname");
            builder.Property(e => e.categoryname).HasMaxLength(15);
            builder.Property(e => e.description).HasMaxLength(200);
        }
    }
}