using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class EmployeeAddressConfiguration : IEntityTypeConfiguration<EmployeeAddress>
    {
        public void Configure(EntityTypeBuilder<EmployeeAddress> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.PostCode).IsRequired();
            builder.Property(x => x.State).IsRequired();
            builder.Property(x => x.Street).IsRequired();
            builder.Property(x => x.City).IsRequired();
            builder.Property(x => x.Country).IsRequired();
            builder.Property(x => x.StreetNumber).IsRequired();
            builder.Property(x => x.PostCode).IsRequired();

            builder.HasOne(e => e.Employee).WithOne(a => a.EmployeeAddress).HasForeignKey<EmployeeAddress>(x => x.EmployeeId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
