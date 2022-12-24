using InvoicerBackendModelsExtension.DomainModels;
using InvoicerBackendModelsExtension.DTOs;
using InvoicerBackendModelsExtension.Responses;
using InvoicerDataExtension.Abstractions;
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
        return new Response<InvoiceDetailDto>(result.Adapt<InvoiceDetailDto>(), Array.Empty<string>(), "Invoice Found", true);
    }

    public async Task<Response<InvoiceCreatedDto>> CreateInvoice(CreateInvoiceDto model)
    {
        if (model is null) return new Response<InvoiceCreatedDto>(null, Array.Empty<string>(), "Post Invalid", false);
        var invoice = model.Adapt<Invoice>();
        var fetchedCustomer = await _customerRepo.GetOneById(new CustomerByIdSpecification(
            model.Customer.CustomerId)).ConfigureAwait(false);
        invoice.InvoicedCustomer = fetchedCustomer ?? model.Customer.Adapt<Customer>();

        var items = model.Items.Adapt<IEnumerable<InvoiceItem>>().ToArray();
        invoice.AddInvoicedItems(items);
        var result = await _repo.CreateOne(invoice).ConfigureAwait(false);
        return new Response<InvoiceCreatedDto>(result.Adapt<InvoiceCreatedDto>(), Array.Empty<string>(), "Successful", true);
    }

    public async Task<EnumerableResponse<InvoiceDetailDto>> GetAllInvoices()
    {
        var result = await _repo.GetMany(new GetAllInvoicesSpecification()).ConfigureAwait(false);

        return new EnumerableResponse<InvoiceDetailDto>(result.Adapt<IEnumerable<InvoiceDetailDto>>(), true);
    }


    public async Task<EnumerableResponse<InvoiceDetailDto>> GetInvoicesSortedByDate()
    {
        var result = await _repo.GetMany(new GetOrderedInvoiceSpecification()).ConfigureAwait(false);

        return new EnumerableResponse<InvoiceDetailDto>(result.Adapt<IEnumerable<InvoiceDetailDto>>(), true);
    }
    
}
