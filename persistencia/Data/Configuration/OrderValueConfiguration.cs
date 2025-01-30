using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    internal class OrderValueConfiguration : IEntityTypeConfiguration<OrderValue>
    {
        public void Configure(EntityTypeBuilder<OrderValue> builder)
        {
            builder
                .HasNoKey()
                .ToView("OrderValues", "Sales");

            builder.Property(e => e.orderdate).HasColumnType("datetime");
            builder.Property(e => e.val).HasColumnType("numeric(12, 2)");
        }
    }
}
