using InvoicerBackendModelsExtension.AbstractTypes;
using SecurityDriven.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicerBackendModelsExtension.DomainModels
{
    public class Customer : BaseEntity
    {
        public Customer(CryptoRandom random) : base(random) { }

        public Customer() { }
        
        public string CustomerName { get; set; } = string.Empty;

        public string CustomerAddress { get; set; } = string.Empty;

        public string CustomerLegacyId { get; set; } = string.Empty;

        public CustomerType CustomerRank { get; set; }
    }
}
