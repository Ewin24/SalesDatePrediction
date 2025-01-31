using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    internal class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(e => new { e.orderid, e.productid });

            builder.ToTable("OrderDetails", "Sales");

            builder.HasIndex(e => e.orderid, "idx_nc_orderid");

            builder.HasIndex(e => e.productid, "idx_nc_productid");

            builder.Property(e => e.discount).HasColumnType("numeric(4, 3)");
            builder.Property(e => e.qty).HasDefaultValue((short)1);
            builder.Property(e => e.unitprice).HasColumnType("money");

            builder.HasOne(d => d.order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.orderid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetails_Orders");

            builder.HasOne(d => d.product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.productid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetails_Products");
        }
    }
}
