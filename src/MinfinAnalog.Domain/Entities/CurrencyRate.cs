namespace MinfinAnalog.Domain.Entities;
public class CurrencyRate
{
    public int Id { get; set; }
    public DateTime ExchangeDate { get; set; }
    public virtual Currency? SourceCurrency { get; set; }
    public virtual Currency? DestinationCurrency { get; set; }
    public decimal Rate { get; set; }

}

