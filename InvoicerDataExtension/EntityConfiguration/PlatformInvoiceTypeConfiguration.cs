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
            builder.HasOne(p => p.Customer)
                .WithMany(c => c.Invoices)
                .HasForeignKey(p => p.CustomerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            builder.OwnsOne(p => p.TotalSum);
            builder.Property(p => p.DateIssued)
                .IsRequired();
            builder.Property(p => p.Description)
                .HasMaxLength(200)
                .IsRequired(false);
        }
    }
}

