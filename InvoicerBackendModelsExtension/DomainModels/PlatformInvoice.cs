using InvoicerBackendModelsExtension.AbstractTypes;
using InvoicerBackendModelsExtension.DomainModels.ValueObjects;
using Mapster;
using InvoicerBackendModelsExtension.DTOs;
using SecurityDriven.Core;

namespace InvoicerBackendModelsExtension.DomainModels;

public class PlatformInvoice : BaseEntity
{
  private List<PlatformService> _services;
  public PlatformInvoice(CryptoRandom random) : base(random)
  {
    _services = new();
  }

  public PlatformInvoice(CreatePlatformInvoiceDto inputModel)
  {
    _services = new();
    ValidateAndSetProperties(inputModel);
  }

  public PlatformInvoice()
  {
    _services = new();
  }

  public DateTime DateIssued { get; private set; }

  public PlatformSubscriptionType SubscriptionType { get; set; }

  public Money TotalSum { get; private set; } = default!;

  public string Description { get; private set; } = string.Empty;

  public Guid CustomerId { get; set; }

  public PlatformCustomer Customer { get; set; } = default!;

  public IReadOnlyList<PlatformService> Services =>
      _services.AsReadOnly();

  private void ValidateAndSetProperties(CreatePlatformInvoiceDto inputModel)
  {
    DateIssued = inputModel.dateIssued;
    Description = inputModel.description;
    SubscriptionType = inputModel.clientSubscription;
    TotalSum = new Money(inputModel.totalSum, inputModel.currency);
    _services = inputModel.services.Select(p => new PlatformService
    {
      ServiceName = p.Name,
      Price = new Money(p.Price, p.Currency)
    }).ToList();
  }
}