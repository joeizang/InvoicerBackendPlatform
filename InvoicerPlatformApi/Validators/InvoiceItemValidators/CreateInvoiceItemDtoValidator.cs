using System;
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
		}
	}
}

