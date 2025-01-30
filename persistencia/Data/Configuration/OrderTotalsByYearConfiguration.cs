using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    internal class OrderTotalsByYearConfiguration : IEntityTypeConfiguration<OrderTotalsByYear>
    {
        public void Configure(EntityTypeBuilder<OrderTotalsByYear> builder)
        {
            builder.HasNoKey().ToView("OrderTotalsByYear", "Sales");
        }
    }
}