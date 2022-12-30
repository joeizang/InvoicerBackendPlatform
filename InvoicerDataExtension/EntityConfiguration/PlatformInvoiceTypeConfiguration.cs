using System;
using InvoicerBackendModelsExtension.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoicerDataExtension.EntityConfiguration
{
	public class PlatformInvoiceTypeConfiguration : IEntityTypeConfiguration<PlatformInvoice>
	{

        public void Configure(EntityTypeBuilder<PlatformInvoice> builder)
        {
            builder.HasMany(p => p.Services)
                .WithOne();
            builder.OwnsOne(p => p.TotalSum);
        }
    }
}

