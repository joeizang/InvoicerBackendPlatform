namespace InvoicerBackendModelsExtension.DomainModels.ValueObjects;

public record Money
{
    public Money(decimal value = 0, CurrencyType currency = CurrencyType.NGN)
    {
        EnsureValueIsValid(value);
        Currency = currency;
    }

    private Money()
    {

    }

    public decimal Value { get; private set; }

    public CurrencyType Currency { get; private set; }

    private void EnsureValueIsValid(decimal value)
    {
        if (decimal.MaxValue == value || decimal.MinValue == value)
            throw new ArgumentException("Illegal amount specified!");
        Value = value;

    }
}

public enum CurrencyType
{
    NGN,
    USD,
    GBP,
    EUR
}