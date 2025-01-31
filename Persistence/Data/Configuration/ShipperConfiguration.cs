using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    internal class ShipperConfiguration : IEntityTypeConfiguration<Shipper>
    {
        public void Configure(EntityTypeBuilder<Shipper> builder)
        {
            builder.ToTable("Shippers", "Sales");

            builder.Property(e => e.companyname).HasMaxLength(40);
            builder.Property(e => e.phone).HasMaxLength(24);
        }
    }
}
