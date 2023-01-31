using InvoicerBackendModelsExtension.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoicerDataExtension.EntityConfiguration;

public class PlatformCustomerTypeConfiguration : IEntityTypeConfiguration<PlatformCustomer>
{
    public void Configure(EntityTypeBuilder<PlatformCustomer> builder)
    {
        builder.HasQueryFilter(pc => !pc.IsDeleted);
        builder.HasKey(pc => pc.Id);
        builder.Property(pc => pc.PlatformCustomerEmail)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(pc => pc.PlatformCustomerName)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(pc => pc.CustomerType)
            .IsRequired();
    }
}