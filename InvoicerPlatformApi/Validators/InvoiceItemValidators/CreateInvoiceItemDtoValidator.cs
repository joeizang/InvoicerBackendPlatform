using System;
using System.Data;
using FluentValidation;
using InvoicerBackendModelsExtension.DTOs;

namespace InvoicerPlatformApi.Validators.InvoiceItemValidators
{
	public class CreateInvoiceItemDtoValidator : AbstractValidator<CreateInvoiceItemDto>
	{
		public CreateInvoiceItemDtoValidator()
		{
            RuleFor(item => item.Quantity)
                .NotEmpty()
                .WithMessage("Cannot be empty or a negative value");
            RuleFor(item => item.Description)
	            .MaximumLength(200)
	            .WithMessage("Description is too long");
            RuleFor(item => item.UnitPrice)
	            .NotEqual(decimal.MinValue)
	            .NotEqual(decimal.MaxValue)
	            .WithMessage("Invalid price set");
		}
	}
}

