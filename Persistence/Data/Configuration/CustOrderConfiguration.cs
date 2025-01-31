using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class CustOrderConfiguration : IEntityTypeConfiguration<CustOrder>
    {
        public void Configure(EntityTypeBuilder<CustOrder> builder)
        {
            builder.HasNoKey();
            builder.ToView("CustOrders", "Sales");
            builder.Property(e => e.ordermonth).HasColumnType("datetime");
        }
    }
}
