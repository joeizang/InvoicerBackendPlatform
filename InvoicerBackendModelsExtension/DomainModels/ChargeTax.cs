namespace InvoicerBackendModelsExtension.DomainModels;

public enum ChargeTax
{
    Taxable = 1,
    NonTaxable,
    ValueAddedTax,
    WithHoldingTax,
    CustomTax
}