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
    public class CustomerTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasQueryFilter(x => !x.IsDeleted);
            builder.Property(x => x.CustomerName)
            .HasMaxLength(70)
            .IsRequired();
            builder.Property(x => x.CustomerAddress)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.CustomerLegacyId)
                .HasMaxLength(50)
                .IsRequired(false);
        }
    }
}
