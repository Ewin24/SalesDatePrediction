using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    internal class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Suppliers", "Production");

            builder.HasIndex(e => e.companyname, "idx_nc_companyname");

            builder.HasIndex(e => e.postalcode, "idx_nc_postalcode");

            builder.Property(e => e.address).HasMaxLength(60);
            builder.Property(e => e.city).HasMaxLength(15);
            builder.Property(e => e.companyname).HasMaxLength(40);
            builder.Property(e => e.contactname).HasMaxLength(30);
            builder.Property(e => e.contacttitle).HasMaxLength(30);
            builder.Property(e => e.country).HasMaxLength(15);
            builder.Property(e => e.fax).HasMaxLength(24);
            builder.Property(e => e.phone).HasMaxLength(24);
            builder.Property(e => e.postalcode).HasMaxLength(10);
            builder.Property(e => e.region).HasMaxLength(15);
        }
    }
}
