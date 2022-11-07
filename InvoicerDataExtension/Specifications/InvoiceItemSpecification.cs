using InvoicerBackendModelsExtension.DomainModels;
using InvoicerDataExtension.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
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
