using InvoicerBackendModelsExtension.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicerDataExtension.EntityConfiguration;

public class InvoiceItemTypeConfiguration : IEntityTypeConfiguration<InvoiceItem>
{
    public void Configure(EntityTypeBuilder<InvoiceItem> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasQueryFilter(item => !item.IsDeleted);

        //builder.HasOne(item => item.Invoice)
        //    .WithMany(item => item.InvoicedItems)
        //    .OnDelete(DeleteBehavior.Restrict);

        builder.Property(item => item.Quantity).IsRequired();
        builder.Property(item => item.UnitPrice).IsRequired();
        builder.Property(item => item.Description)
            .HasMaxLength(200)
            .IsRequired(false);
    }
}
