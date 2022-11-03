using InvoicerBackendModelsExtension.AbstractTypes;
using SecurityDriven.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicerBackendModelsExtension.DomainModels
{
    public class InvoiceItem : BaseEntity
    {
        public InvoiceItem(CryptoRandom random) : base(random)
        {
        }

        private InvoiceItem()
        {

        }

        public double Quantity { get; set; }

        public string Description { get; set; } = string.Empty;

        public decimal UnitPrice { get; set; }

        public Guid InvoiceId { get; set; }

        public Invoice Invoice { get; set; } = default!;

    }
}
