using InvoicerBackendModelsExtension.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicerDataExtension.EntityConfiguration;

public class InvoiceTypeConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasQueryFilter(x => !x.IsDeleted);

        builder.HasMany(x => x.InvoicedItems)
            .WithOne(x => x.Invoice)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.BriefInvoiceDescription)
            .HasMaxLength(100)
            .IsRequired(false);
        builder.Property(x => x.BusinessTagLine)
            .HasMaxLength(50);
        builder.Property(x => x.BusinessName)
            .HasMaxLength(50)
            .IsRequired();
        builder.Property(x => x.InvoiceDate)
            .IsRequired();
        builder.Property(x => x.Logo)
            .HasMaxLength(250)
            .IsRequired(false);
        builder.Property(x => x.SignatureUrl)
            .HasMaxLength(150)
            .IsRequired();
        builder.Property(x => x.OtherInfo)
            .HasMaxLength(200)
            .IsRequired(false);
    }
}
