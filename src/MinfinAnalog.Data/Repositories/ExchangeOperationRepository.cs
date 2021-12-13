using MinfinAnalog.Domain.Entities;
using MinfinAnalog.Domain.Interfaces;

namespace MinfinAnalog.Data.Repositories;

public class ExchangeOperationRepository : Repository<UserExchangeOperation>, IExchangeOperationRepository
{
    public ExchangeOperationRepository(MinfinAnalogContext context) : base(context)
    {
    }

    public MinfinAnalogContext MinfinAnalogContext
    {
        get { return Context as MinfinAnalogContext ?? throw new ArgumentNullException(nameof(Context)); }
    }

    public decimal GetExchangeBalance(int userId, int currencyId)
    {
        decimal totalExchangeAmount = 0.0m;
            // TODO = MinfinAnalogContext.ExchangeOperations.Where(eo => eo.User.Id == userId && eo.SourceCurrency.Id == currencyId).Sum(eo => eo.Amount * eo.Rate);

        return totalExchangeAmount;
    }
}

