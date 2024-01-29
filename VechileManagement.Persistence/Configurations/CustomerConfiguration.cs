using VechileManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VechileManagement.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder) 
        {
            builder.Property(x => x.Id)
                .HasDefaultValueSql("NEWID()");
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.OwnsOne(c => c.Address);
        }
    }
}
