namespace MinfinAnalog.Domain.Entities;
public class UserExchangeOperation
{
    public int Id { get; set; }
    public virtual User User { get; set; } = null!;
    public virtual Currency? SourceCurrency { get; set; }
    public virtual Currency? DestinationCurrency { get; set; }
    public DateTime ExchangeOperationDate { get; set; }
    public decimal Amount { get; set; }
    public decimal BankFee { get; set; }
}
