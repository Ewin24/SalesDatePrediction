using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data.Configuration
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders", "Sales");

            builder.HasIndex(e => e.custid, "idx_nc_custid");

            builder.HasIndex(e => e.empid, "idx_nc_empid");

            builder.HasIndex(e => e.orderdate, "idx_nc_orderdate");

            builder.HasIndex(e => e.shippeddate, "idx_nc_shippeddate");

            builder.HasIndex(e => e.shipperid, "idx_nc_shipperid");

            builder.HasIndex(e => e.shippostalcode, "idx_nc_shippostalcode");

            builder.Property(e => e.freight).HasColumnType("money");
            builder.Property(e => e.orderdate).HasColumnType("datetime");
            builder.Property(e => e.requireddate).HasColumnType("datetime");
            builder.Property(e => e.shipaddress).HasMaxLength(60);
            builder.Property(e => e.shipcity).HasMaxLength(15);
            builder.Property(e => e.shipcountry).HasMaxLength(15);
            builder.Property(e => e.shipname).HasMaxLength(40);
            builder.Property(e => e.shippeddate).HasColumnType("datetime");
            builder.Property(e => e.shippostalcode).HasMaxLength(10);
            builder.Property(e => e.shipregion).HasMaxLength(15);

            builder.HasOne(d => d.cust).WithMany(p => p.Orders)
                .HasForeignKey(d => d.custid)
                .HasConstraintName("FK_Orders_Customers");

            builder.HasOne(d => d.emp).WithMany(p => p.Orders)
                .HasForeignKey(d => d.empid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Employees");

            builder.HasOne(d => d.shipper).WithMany(p => p.Orders)
                .HasForeignKey(d => d.shipperid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Shippers");
        }
    }
}
