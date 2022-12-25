using System;
using FluentValidation;
using InvoicerBackendModelsExtension.DTOs;

namespace InvoicerPlatformApi.Validators.InvoiceItemValidators
{
	public class CreateInvoiceItemDtoValidator : AbstractValidator<CreateInvoiceItemDto>
	{
		public CreateInvoiceItemDtoValidator()
		{
		}
	}
}

