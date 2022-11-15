using InvoicerBackendModelsExtension.DomainModels;
using InvoicerDataExtension.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InvoicerDataExtension.Specifications;

public class InvoiceItemsByInvoiceIdSpecification : Specification<InvoiceItem>
{
    public InvoiceItemsByInvoiceIdSpecification(Guid invoiceId)
        : base(x => x.InvoiceId == invoiceId)
    {
        AddInclude(x => x.Invoice);
    }
}

public class InvoiceItemByInvoiceItemIdSpecification : Specification<InvoiceItem>
{
    public InvoiceItemByInvoiceItemIdSpecification(Guid id)
        : base(x => x.Id == id)
    {
    }
}
