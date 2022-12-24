using System;
using FluentValidation;
using InvoicerBackendModelsExtension.DTOs;

namespace InvoicerPlatformApi.Validators.InvoiceValidators;

public class CreateInvoiceDtoValidator : AbstractValidator<CreateInvoiceDto>
{
	public CreateInvoiceDtoValidator()
	{
		RuleFor(invoice => invoice.BusinessName)
			.MinimumLength(2)
			.MaximumLength(200)
			.NotEmpty()
			.WithMessage("Business Name is not optional.")
			.WithErrorCode("400");
		RuleFor(invoice => invoice.Customer)
			.NotNull()
			.WithMessage("There must be a customer receiving an invoice")
			.WithErrorCode("400");
		RuleFor(invoice => invoice.Customer.CustomerName)
			.MinimumLength(2)
			.MaximumLength(200)
			.NotEmpty()
			.WithMessage("Customer Name is not optional")
			.WithErrorCode("400");
		RuleFor(invoice => invoice.Customer.CustomerAddress)
			.MinimumLength(15)
			.MaximumLength(150)
			.NotEmpty()
			.WithMessage("Every customer must have an address")
			.WithErrorCode("400");
		RuleFor(invoice => invoice.Customer.CustomerId)
			.NotEmpty();
		RuleFor(invoice => invoice.InvoiceDate)
			.LessThan(DateOnly.FromDateTime(DateTime.Now.AddMonths(-3)))
			.GreaterThan(DateOnly.FromDateTime(DateTime.Now.AddMonths(1)))
			.WithMessage("Invoices cannot have a date in the past longer than 3 months from when the invoice was created and it also cannot have a date more than a month in the future from when an invoice has been created");
		RuleFor(invoice => invoice.Tax)
			.GreaterThan(0.05) // values should be configurable so users can supply their tax values
			.LessThan(0.11)
			.WithMessage("{PropertyName} cannot be less than the minimum stipulated by law and cannot be more than maximum allowed by law");
		RuleFor(invoice => invoice.Total)
			.NotEmpty()
			.GreaterThan(0)
			.WithMessage("An invoice must have a Total sum");
		RuleFor(invoice => invoice.SignatureUrl)
			.NotEmpty()
			.WithMessage("An invoice cannot be created without a valid signature.");
			
	}
}

