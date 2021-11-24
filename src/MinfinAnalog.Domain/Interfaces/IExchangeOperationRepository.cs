using MinfinAnalog.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MinfinAnalog.Domain.Interfaces;
public interface IExchangeOperationRepository : IRepository<ExchangeOperation>
{
    decimal GetExchangeBalance(int userId, int currencyId);
}

