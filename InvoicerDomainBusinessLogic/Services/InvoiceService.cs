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

        try
        {
            var result = await _repo.GetOneByPredicates<InvoiceDetailDto>(includes, x => x.Id.Equals(invoiceId))
                            .ConfigureAwait(false);
            return result is not null ? new Response<InvoiceDetailDto>(result, new string[] { }, "Invoice Found", true)
                    : new Response<InvoiceDetailDto>(null, new string[] { "Invoice Not Found" }, "Not Found", false);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<Response<InvoiceCreatedDto>>
}
