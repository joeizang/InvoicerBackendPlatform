using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicerBackendModelsExtension.DTOs;

public record CreateInvoiceItemDto(Guid ItemId, double Quantity, string Description, decimal UnitPrice);
