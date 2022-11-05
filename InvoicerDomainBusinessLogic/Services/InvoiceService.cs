using InvoicerBackendModelsExtension.DomainModels;
using InvoicerBackendModelsExtension.DTOs;
using InvoicerBackendModelsExtension.Responses;
using InvoicerDataExtension.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Mapster;

namespace InvoicerDomainBusinessLogic.Services;

public class InvoiceService
{
    private readonly IGenericRepository<Invoice> _repo;
    public InvoiceService(IGenericRepository<Invoice> repo)
    {
        _repo = repo;
    }

    public async Task<Response<InvoiceDetailDto>> GetInvoiceById(Guid invoiceId)
    {
        var includes = new Expression<Func<Invoice, object>>[]
        {
            x => x.InvoicedItems,
            x => x.InvoicedCustomer
        };

        var result = await _repo.GetOneByPredicates<InvoiceDetailDto>(includes, x => x.Id.Equals(invoiceId))
            .ConfigureAwait(false);
        return new Response<InvoiceDetailDto>(result, new string[] { }, "Invoice Found", true);
    }

    public async Task<Response<InvoiceCreatedDto>> CreateInvoice(CreateInvoiceDto model)
    {
        var invoice = model.Adapt<Invoice>();
        var fetchedCustomer = await _repo.GetOneById<CustomerDto>(model.Customer.CustomerId).ConfigureAwait(false);
        invoice.InvoicedCustomer = fetchedCustomer.Adapt<Customer>();

        var items = model.Items.Adapt<IEnumerable<InvoiceItem>>().ToArray();
        invoice.AddInvoicedItems(items);
        var result = await _repo.CreateOne<InvoiceCreatedDto>(invoice).ConfigureAwait(false);
        return new Response<InvoiceCreatedDto>(result, Array.Empty<string>(), "Successful", true);
    }
    
}
