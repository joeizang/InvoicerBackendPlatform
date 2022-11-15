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


    public async  Task<EnumerableResponse<InvoiceItemDto>> GetInvoiceItems(Guid invoiceId)
    {
        var result = await _itemRepo.GetMany(new InvoiceItemsByInvoiceIdSpecification(invoiceId)).ConfigureAwait(false);
        return new EnumerableResponse<InvoiceItemDto>(result.Adapt<IEnumerable<InvoiceItemDto>>(), true);
    }

    public async Task<Response<InvoiceItemDto>> CreateInvoiceItem(InvoiceItemDto input)
    {
        var result = await _itemRepo.CreateOne(input.Adapt<InvoiceItem>()).ConfigureAwait(false);
        return result is not null ? new Response<InvoiceItemDto>(result.Adapt<InvoiceItemDto>(),
            null, "Created successfully", true) : new Response<InvoiceItemDto>(null,
            new string[] { "There was an error creating the item" }, "Error creating entity", false);
    }

    public async Task<Response<InvoiceItemDto>> DeleteInvoiceItem(Guid invoiceItemId)
    {

        var item = await _itemRepo.GetOneById(new InvoiceItemByInvoiceItemIdSpecification(invoiceItemId))
            .ConfigureAwait(false);
        var result = await _itemRepo.DeleteOne(item).ConfigureAwait(false);

        if (result is null) return new Response<InvoiceItemDto>(result?.Adapt<InvoiceItemDto>(),
            new[] { "Bad Request" }, "Deletion was not possible", false);
        else
            return new Response<InvoiceItemDto>(result.Adapt<InvoiceItemDto>(),
                new[] { "" }, "Delete Successful", true);
    }

    public async Task<Response<InvoiceItemDto>> UpateInvoiceItem(InvoiceItemDto input)
    {
        var item = await _itemRepo.GetOneById(new InvoiceItemByInvoiceItemIdSpecification(input.ItemId))
            .ConfigureAwait(false);
        item.Quantity = input.Quantity;
        item.UnitPrice = input.UnitPrice;
        item.Description = input.Description;
        item.UpdatedAt = DateTimeOffset.Now;

        var result = await _itemRepo.EditOne(item).ConfigureAwait(false);

        return result is null ? new Response<InvoiceItemDto>(result?.Adapt<InvoiceItemDto>(), new[] { "" },
            "Error updating item", false) : new Response<InvoiceItemDto>(result?.Adapt<InvoiceItemDto>(),
            new[] { "" }, "Update Successfl", true);
    }

    
}
