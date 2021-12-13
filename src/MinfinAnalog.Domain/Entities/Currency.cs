namespace MinfinAnalog.Domain.Entities;

public class Currency
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string CurrencyCode { get; set; } = string.Empty;
}
