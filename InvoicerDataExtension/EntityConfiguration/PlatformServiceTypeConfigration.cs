using System;
using InvoicerBackendModelsExtension.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoicerDataExtension.EntityConfiguration
{
	public class PlatformServiceTypeConfigration : IEntityTypeConfiguration<PlatformService>
	{
		public PlatformServiceTypeConfigration()
		{
		}

        public void Configure(EntityTypeBuilder<PlatformService> builder)
        {
            builder.HasKey(ps => ps.Id);
            builder.OwnsOne(ps => ps.Price);
            builder.Property(ps => ps.ServiceName)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(ps => ps.ServiceDescription)
                .HasMaxLength(300);
        }
    }
}

