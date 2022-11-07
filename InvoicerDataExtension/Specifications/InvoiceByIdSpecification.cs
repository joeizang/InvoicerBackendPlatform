using InvoicerBackendModelsExtension.DomainModels;
using InvoicerDataExtension.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
