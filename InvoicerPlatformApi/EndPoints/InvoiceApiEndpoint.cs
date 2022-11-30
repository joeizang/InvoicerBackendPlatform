

using InvoicerBackendModelsExtension.DTOs;
using InvoicerDomainBusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace InvoicerPlatformApi.EndPoints
{
    internal static class InvoiceApiEndpoints
    {
        public static RouteGroupBuilder MapInvoices(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("invoices");

            group.MapGet("/", async (InvoiceService service) =>
            {
                var result = await service.GetAllInvoices().ConfigureAwait(false);
                return Results.Ok(result);
            })
            .Produces<InvoiceDetailDto>()
            .Produces(StatusCodes.Status200OK);


            group.MapGet("/{id}", async (InvoiceService service, Guid id) =>
            {
                if (id == Guid.Empty) return Results.BadRequest();
                var result = await service.GetInvoiceById(id).ConfigureAwait(false);
                return result.Success is true ? Results.Ok(result) : Results.NotFound();
            })
            .Produces<InvoiceDetailDto>()
            .Produces(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound);


            group.MapPost("/", async (InvoiceService service, [FromBody] CreateInvoiceDto inputModel) =>
            {
                var result = await service.CreateInvoice(inputModel).ConfigureAwait(false);
            });


            return group;
        }
    }
}
