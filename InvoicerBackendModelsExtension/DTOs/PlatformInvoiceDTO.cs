using InvoicerBackendModelsExtension.DomainModels;
using InvoicerBackendModelsExtension.DomainModels.ValueObjects;

namespace InvoicerBackendModelsExtension.DTOs;

public record CreatePlatformInvoiceDto(DateTime dateIssued, PlatformSubscriptionType clientSubscription, decimal totalSum,
    CurrencyType currency,string description, List<PlatformServiceDTO> services);
    
public record PlatformServiceDTO(string Name, decimal Price, CurrencyType Currency);