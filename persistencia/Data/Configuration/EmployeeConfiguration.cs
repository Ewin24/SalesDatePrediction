using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.empid);

            builder.ToTable("Employees", "HR");

            builder.HasIndex(e => e.lastname, "idx_nc_lastname");

            builder.HasIndex(e => e.postalcode, "idx_nc_postalcode");

            builder.Property(e => e.address).HasMaxLength(60);
            builder.Property(e => e.birthdate).HasColumnType("datetime");
            builder.Property(e => e.city).HasMaxLength(15);
            builder.Property(e => e.country).HasMaxLength(15);
            builder.Property(e => e.firstname).HasMaxLength(10);
            builder.Property(e => e.hiredate).HasColumnType("datetime");
            builder.Property(e => e.lastname).HasMaxLength(20);
            builder.Property(e => e.phone).HasMaxLength(24);
            builder.Property(e => e.postalcode).HasMaxLength(10);
            builder.Property(e => e.region).HasMaxLength(15);
            builder.Property(e => e.title).HasMaxLength(30);
            builder.Property(e => e.titleofcourtesy).HasMaxLength(25);

            builder.HasOne(d => d.mgr).WithMany(p => p.Inversemgr)
                .HasForeignKey(d => d.mgrid)
                .HasConstraintName("FK_Employees_Employees");
        }
    }
}
