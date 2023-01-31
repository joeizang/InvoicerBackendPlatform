using System.Collections.Generic;
using InvoicerBackendModelsExtension.AbstractTypes;
using InvoicerBackendModelsExtension.DTOs;
using SecurityDriven.Core;

namespace InvoicerBackendModelsExtension.DomainModels;

public class PlatformCustomer : BaseEntity
{
  private readonly List<PlatformInvoice> _invoices;
  public PlatformCustomer(CryptoRandom random) : base(random)
  {
    _invoices = new List<PlatformInvoice>();
  }

  public PlatformCustomer(CreatePlatformCustomerDto inputModel)
  {
    _invoices = new List<PlatformInvoice>();
  }

  public PlatformCustomer()
  {
    _invoices = new List<PlatformInvoice>();
  }

  public IEnumerable<PlatformInvoice> Invoices => _invoices.AsReadOnly();

  public string PlatformCustomerName { get; set; } = string.Empty;

  public string PlatformCustomerEmail { get; set; } = string.Empty;

  public PlatformCustomerType CustomerType { get; set; }

  private void InitializePlatformCustomer(CreatePlatformCustomerDto inputModel)
  {

  }



}