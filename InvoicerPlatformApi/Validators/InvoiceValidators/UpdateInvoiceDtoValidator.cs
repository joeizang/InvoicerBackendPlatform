using System;
using FluentValidation;
using InvoicerBackendModelsExtension.DTOs;

namespace InvoicerPlatformApi.Validators.InvoiceValidators
{
	public class UpdateInvoiceDtoValidator : AbstractValidator<UpdateInvoiceDto>
	{
		public UpdateInvoiceDtoValidator()
		{
		}
	}
}

