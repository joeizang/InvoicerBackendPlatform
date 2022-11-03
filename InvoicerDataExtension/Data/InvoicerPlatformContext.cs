using InvoicerBackendModelsExtension.DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InvoicerDataExtension.Data
{
    public class InvoicerPlatformContext : DbContext
    {
        public InvoicerPlatformContext(DbContextOptions<InvoicerPlatformContext> options)
            : base(options)
        {

        }

        public InvoicerPlatformContext(
            DbContextOptionsBuilder<InvoicerPlatformContext> options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<InvoiceItem> InvoiceItems { get; set; }

        public DbSet<Customer> Customers { get; set; }

    }
}
