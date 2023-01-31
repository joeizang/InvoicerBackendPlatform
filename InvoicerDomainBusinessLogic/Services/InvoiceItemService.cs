using InvoicerBackendModelsExtension.DomainModels;
using InvoicerBackendModelsExtension.DTOs;
using InvoicerBackendModelsExtension.Responses;
using InvoicerDataExtension.Abstractions;
using InvoicerDataExtension.Specifications;
using Mapster;

namespace InvoicerDomainBusinessLogic.Services;

public class InvoiceItemService
{
    private readonly IGenericRepository<InvoiceItem> _itemRepo;

    public InvoiceItemService(IGenericRepository<InvoiceItem> itemRepo)
    {
        _itemRepo = itemRepo;
    }


    public async  Task<EnumerableResponse<CreateInvoiceItemDto>> GetInvoiceItems(Guid invoiceId)
    {
        var result = await _itemRepo.GetMany(new InvoiceItemsByInvoiceIdSpecification(invoiceId)).ConfigureAwait(false);
        return new EnumerableResponse<CreateInvoiceItemDto>(result.Adapt<IEnumerable<CreateInvoiceItemDto>>(), true);
    }

    public async Task<Response<CreateInvoiceItemDto>> CreateInvoiceItem(CreateInvoiceItemDto input)
    {
        var result = await _itemRepo.CreateOne(input.Adapt<InvoiceItem>()).ConfigureAwait(false);
        return new Response<CreateInvoiceItemDto>(result.Adapt<CreateInvoiceItemDto>(),
            null, "Created successfully", true);
    }

    public async Task<Response<CreateInvoiceItemDto>> DeleteInvoiceItem(Guid invoiceItemId)
    {

        var item = await _itemRepo.GetOneById(new InvoiceItemByInvoiceItemIdSpecification(invoiceItemId))
            .ConfigureAwait(false);
        var result = await _itemRepo.DeleteOne(item).ConfigureAwait(false);

        return new Response<CreateInvoiceItemDto>(result.Adapt<CreateInvoiceItemDto>(),
            new[] { "" }, "Delete Successful", true);
    }

    public async Task<Response<CreateInvoiceItemDto>> UpateInvoiceItem(CreateInvoiceItemDto input)
    {
        var item = await _itemRepo.GetOneById(new InvoiceItemByInvoiceItemIdSpecification(input.ItemId))
            .ConfigureAwait(false);
        item.Quantity = input.Quantity;
        item.UnitPrice = input.UnitPrice;
        item.Description = input.Description;
        item.UpdatedAt = DateTimeOffset.Now;

        var result = await _itemRepo.EditOne(item).ConfigureAwait(false);

        return new Response<CreateInvoiceItemDto>(result.Adapt<CreateInvoiceItemDto>(),
            new[] { "" }, "Update Successful", true);
    }

    
}
