using InvoicerBackendModelsExtension.AbstractTypes;
using SecurityDriven.Core;

namespace InvoicerBackendModelsExtension.DomainModels;

public class PlatformCustomer : BaseEntity
{
    public PlatformCustomer(CryptoRandom random) : base(random)
    {
        
    }

    public List<PlatformInvoice> Invoices { get; set; }

    public string PlatformCustomerName { get; set; }

    public string PlatformCustomerEmail { get; set; }

    public PlatformCustomerType CustomerType { get; set; }
    
    
    
}