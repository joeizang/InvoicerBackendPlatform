using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicerBackendModelsExtension.DTOs
{
    public record InvoiceCreatedDto(Guid InvoiceId, string CustomerName, string CustomerEmail,
        DateTimeOffset CreatedAt)
    {
    }
}
