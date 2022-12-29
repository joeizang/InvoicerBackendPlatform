using InvoicerBackendModelsExtension.AbstractTypes;
using SecurityDriven.Core;

namespace InvoicerBackendModelsExtension.DomainModels;

public class PlatformInvoice : BaseEntity
{
    public PlatformInvoice(CryptoRandom random) : base(random)
    {
        
    }

    public DateTime DateIssued { get; private set; }

    public PlatformSubscriptionType SubscriptionType { get; set; }

    public Guid CustomerId { get; set; }

    public PlatformCustomer Customer { get; set; }
    
    
}