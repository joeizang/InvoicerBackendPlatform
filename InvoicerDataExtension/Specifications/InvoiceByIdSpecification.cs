using InvoicerBackendModelsExtension.DomainModels;
using InvoicerDataExtension.Abstractions;

namespace InvoicerDataExtension.Specifications;

public class InvoiceByIdSpecification : Specification<Invoice>
{
    public InvoiceByIdSpecification(Guid invoiceId)
        : base(x => x.Id.Equals(invoiceId))
    {
        AddInclude(x => x.InvoicedItems);
        AddInclude(x => x.InvoicedCustomer);
    }
}

