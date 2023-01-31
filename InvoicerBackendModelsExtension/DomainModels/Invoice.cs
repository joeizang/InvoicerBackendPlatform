using InvoicerBackendModelsExtension.AbstractTypes;
using SecurityDriven.Core;
using InvoicerBackendModelsExtension.DomainModels.ValueObjects;

namespace InvoicerBackendModelsExtension.DomainModels;

public class Invoice : BaseEntity
{
    private Invoice() { _invoiceItems = new List<InvoiceItem>(); Total = new Money(); }
    public Invoice(CryptoRandom random) : base(random)
    {
        _invoiceItems = new List<InvoiceItem>();
        Total = new Money();
    }

    private readonly List<InvoiceItem> _invoiceItems;

    public string BriefInvoiceDescription { get; set; } = string.Empty;

    public string SignatureUrl { get; set; } = string.Empty;

    public string Logo { get; set; } = string.Empty;

    public string BusinessTagLine { get; set; } = string.Empty;

    public string BusinessName { get; set; } = string.Empty; 

    public DateOnly InvoiceDate { get; set; }

    public bool InValidateInvoice { get; set; } = true;

    public Money Total { get; set; }

    public ChargeTax TaxType { get; set; }

    public double Tax { get; set; }

    public string OtherInfo { get; set; } = string.Empty;

    public IReadOnlyCollection<InvoiceItem> InvoicedItems 
        => _invoiceItems.AsReadOnly();

    public void AddInvoicedItems(InvoiceItem[] items)
    {
        if (!items.Any())
            throw new ArgumentException(
                "An invoice cannot be created without at least one item being invoiced for!");
        var length = items.Length;
        var count = 0;

        while (count < length)
        {
            _invoiceItems.Add(items[count]);
            count++;
        }
    }
    
    public void ValidateInvoice()
    {
        if (InValidateInvoice)
            InValidateInvoice = true;
    }
}
