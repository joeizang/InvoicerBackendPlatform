namespace InvoicerBackendModelsExtension.DTOs;

public record CreateInvoiceDto(string BriefInvoiceDescription, string SignatureUrl, string Logo, string BusinessTagLine,
    string BusinessName, DateOnly InvoiceDate, decimal Total, double Tax, string OtherInfo, CustomerDto Customer,
    IEnumerable<CreateInvoiceItemDto> Items);


public record UpdateInvoiceDto();