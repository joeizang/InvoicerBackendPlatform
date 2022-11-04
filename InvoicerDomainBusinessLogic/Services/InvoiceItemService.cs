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

namespace InvoicerDomainBusinessLogic.Services
{
    public class InvoiceItemService
    {
        private readonly IGenericRepository<InvoiceItem> _itemRepo;

        public InvoiceItemService(IGenericRepository<InvoiceItem> itemRepo)
        {
            _itemRepo = itemRepo;
        }

        public SearchParams<InvoiceItem> SearchItems { get; set; }

        public async  Task<EnumerableResponse<InvoiceItemDto>> GetInvoiceItems(Guid invoiceId)
        {
            var search = new Expression<Func<InvoiceItem, object>>[]
            {
                x => x.Invoice
            };
            var result = await _itemRepo.GetMany<InvoiceItemDto>(search, x => x.InvoiceId.Equals(invoiceId)).ConfigureAwait(false);
            return new EnumerableResponse<InvoiceItemDto>(result, true);
        }

        
    }
}
