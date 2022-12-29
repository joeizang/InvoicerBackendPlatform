using InvoicerBackendModelsExtension.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicerDataExtension.EntityConfiguration
{
    public class CustomerTypeConfiguration : IEntityTypeConfiguration<PlatformCustomer>
    {
        public void Configure(EntityTypeBuilder<PlatformCustomer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasQueryFilter(x => !x.IsDeleted);
            builder.Property(x => x.PlatformCustomerName)
            .HasMaxLength(70)
            .IsRequired();
            builder.Property(x => x.PlatformCustomerEmail)
                .HasMaxLength(100)
                .IsRequired();
            builder.HasMany(pc => pc.Invoices)
                .WithOne(pi => pi.Customer)
                .IsRequired()
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
