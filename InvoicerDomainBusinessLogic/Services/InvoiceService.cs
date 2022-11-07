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
using InvoicerDataExtension.Specifications;

namespace InvoicerDomainBusinessLogic.Services;

public class InvoiceService
{
    private readonly IGenericRepository<Invoice> _repo;
    private readonly IGenericRepository<Customer> _customerRepo;

    public InvoiceService(IGenericRepository<Invoice> repo, IGenericRepository<Customer> customerRepo)
    {
        _repo = repo;
        _customerRepo = customerRepo;
    }

    public async Task<Response<InvoiceDetailDto>> GetInvoiceById(Guid invoiceId)
    {

        var result = await _repo.GetOneByPredicates(new InvoiceByIdSpecification(invoiceId))
            .ConfigureAwait(false);
        return new Response<InvoiceDetailDto>(result.Adapt<InvoiceDetailDto>(), new string[] { }, "Invoice Found", true);
    }

    public async Task<Response<InvoiceCreatedDto>> CreateInvoice(CreateInvoiceDto model)
    {
        var invoice = model.Adapt<Invoice>();
        var fetchedCustomer = await _customerRepo.GetOneById(new CustomerByIdSpecification(
            model.Customer.CustomerId)).ConfigureAwait(false);
        invoice.InvoicedCustomer = fetchedCustomer ?? model.Customer.Adapt<Customer>();

        var items = model.Items.Adapt<IEnumerable<InvoiceItem>>().ToArray();
        invoice.AddInvoicedItems(items);
        var result = await _repo.CreateOne(invoice).ConfigureAwait(false);
        return new Response<InvoiceCreatedDto>(result.Adapt<InvoiceCreatedDto>(), Array.Empty<string>(), "Successful", true);
    }
    
}
