namespace InvoicerBackendModelsExtension.DTOs;

public record CreateInvoiceDto(string BriefInvoiceDescription, string SignatureUrl, string Logo, string BusinessTagLine,
    string BusinessName, DateOnly InvoiceDate, decimal Total, double Tax, string OtherInfo, string CustomerName,
    string CustomerAddress, string CustomerNumber, IEnumerable<CreateInvoiceItemDto> Items);


public record UpdateInvoiceDto(string BriefInvoiceDescription, string SignatureUrl, string Logo, string BusinessTagLine,
    string BusinessName, DateOnly InvoiceDate, decimal Total, double Tax, string OtherInfo, string CustomerName,
    string CustomerAddress, string CustomerNumber, IEnumerable<CreateInvoiceItemDto> Items);