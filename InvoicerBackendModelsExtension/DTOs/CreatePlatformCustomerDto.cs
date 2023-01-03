
using InvoicerBackendModelsExtension.DomainModels;

namespace InvoicerBackendModelsExtension.DTOs;

public record CreatePlatformCustomerDto(
  string PlatformCustomerName, string PlatformCustomerEmail, PlatformCustomerType CustomerType
);