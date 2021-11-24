namespace MinfinAnalog.Data.Entities;
public class ExchangeOperation
{
    public int Id { get; set; }
    public virtual User User { get; set; }
    public virtual Currency SourceCurrency { get; set; }
    public virtual Currency DestinationCurrency { get; set; }
    public DateTime ExchangeOperationDate { get; set; }
    public decimal Amount { get; set; }
    public decimal BankFee { get; set; }
}
