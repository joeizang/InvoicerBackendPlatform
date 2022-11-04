using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicerBackendModelsExtension.DTOs;

public record InvoiceDetailDto(string BriefInvoiceDescription,string SignatureUrl,
    string Logo,string BusinessTagLine,string BusinessName, DateOnly InvoiceDate, decimal Total,double Tax,
    CustomerDto Customer, IEnumerable<InvoiceItemDto> InvoiceItems);
