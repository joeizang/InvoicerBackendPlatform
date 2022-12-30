using InvoicerBackendModelsExtension.AbstractTypes;
using InvoicerBackendModelsExtension.DomainModels.ValueObjects;
using SecurityDriven.Core;

namespace InvoicerBackendModelsExtension.DomainModels;

public class PlatformService : BaseEntity
{
    public PlatformService(CryptoRandom random) : base(random)
    {
        
    }

    public PlatformService()
    {
        
    }

    public string ServiceName { get; set; } = string.Empty;

    public string ServiceDescription { get; set; } = string.Empty;

    public Money Price { get; set; } = default!;
}