

using FluentValidation;
using InvoicerBackendModelsExtension.DTOs;
using InvoicerBackendModelsExtension.Responses;
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
            .Produces<EnumerableResponse<InvoiceDetailDto>>()
            .Produces(StatusCodes.Status200OK);


            group.MapGet("/{id:guid}", async (InvoiceService service, Guid id) =>
            {
                if (id == Guid.Empty) return Results.BadRequest();
                var result = await service.GetInvoiceById(id).ConfigureAwait(false);
                return result.Success is true ? Results.Ok(result) : Results.NotFound();
            })
            .Produces<Response<InvoiceDetailDto>>()
            .Produces(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound);


            group.MapPost("/", async (InvoiceService service, IValidator<CreateInvoiceDto> validator, [FromBody] CreateInvoiceDto inputModel) =>
            {
                var check = validator.Validate(inputModel);
                if (!check.IsValid && check.Errors.Any()) return Results.ValidationProblem((IDictionary<string, string[]>)check.Errors.ToDictionary(x => x.PropertyName));
                try
                {
                    var result = await service.CreateInvoice(inputModel).ConfigureAwait(false);
                    if (!result.Success && result.Data is null) return Results.BadRequest(result.Errors);
                    return Results.Ok(result);
                }
                catch(Exception ex)
                {
                    return Results.Problem(ex.Message);
                }

            })
            .Produces<Response<InvoiceDetailDto>>()
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);


            return group;
        }
    }
}
