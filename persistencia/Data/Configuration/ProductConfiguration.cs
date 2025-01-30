using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", "Production");

            builder.HasIndex(e => e.categoryid, "idx_nc_categoryid");

            builder.HasIndex(e => e.productname, "idx_nc_productname");

            builder.HasIndex(e => e.supplierid, "idx_nc_supplierid");

            builder.Property(e => e.productname).HasMaxLength(40);
            builder.Property(e => e.unitprice).HasColumnType("money");

            builder.HasOne(d => d.category).WithMany(p => p.Products)
                .HasForeignKey(d => d.categoryid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Categories");

            builder.HasOne(d => d.supplier).WithMany(p => p.Products)
                .HasForeignKey(d => d.supplierid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Suppliers");
        }
    }
}
