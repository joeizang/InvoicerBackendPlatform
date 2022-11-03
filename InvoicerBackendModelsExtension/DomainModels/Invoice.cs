using InvoicerBackendModelsExtension.AbstractTypes;
using SecurityDriven.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicerBackendModelsExtension.DomainModels;

public class Invoice : BaseEntity
{
    private Invoice() { _invoiceItems = new(); }
    public Invoice(CryptoRandom random) : base(random)
    {
        _invoiceItems = new List<InvoiceItem>();
    }

    private List<InvoiceItem> _invoiceItems;

    public Customer InvoicedCustomer { get; set; } = default!;

    public Guid CustomerId { get; set; }

    public string BriefInvoiceDescription { get; set; } = string.Empty;

    public string SignatureUrl { get; set; } = string.Empty;

    public string Logo { get; set; } = string.Empty;

    public string BusinessTagLine { get; set; } = string.Empty;

    public string BusinessName { get; set; } = string.Empty; 

    public DateOnly InvoiceDate { get; set; }

    public decimal Total { get; set; }

    public double Tax { get; set; }

    public string OtherInfo { get; set; } = string.Empty;

    public IReadOnlyCollection<InvoiceItem> InvoicedItems 
        => _invoiceItems.AsReadOnly();
}
