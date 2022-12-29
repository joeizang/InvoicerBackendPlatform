using InvoicerBackendModelsExtension.DomainModels;
using InvoicerDataExtension.Abstractions;
using System.Linq.Expressions;

namespace InvoicerDataExtension.Specifications;

public class InvoiceByIdSpecification : Specification<Invoice>
{
    public InvoiceByIdSpecification(Guid invoiceId)
        : base(x => x.Id.Equals(invoiceId))
    {
        AddInclude(x => x.InvoicedItems);
    }
}

public class GetAllInvoicesSpecification : Specification<Invoice>
{
    public GetAllInvoicesSpecification()
        : base(x => !x.Id.Equals(Guid.Empty))
    {
        AddInclude(x => x.InvoicedItems);
    }
}


public class GetOrderedInvoiceSpecification : Specification<Invoice>
{
    public GetOrderedInvoiceSpecification()
        : base(x => !x.Id.Equals(Guid.Empty))
    {
        AddInclude(x => x.InvoicedItems);
        AddOrderBy(x => x.InvoiceDate);
    }
}