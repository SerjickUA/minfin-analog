using MinfinAnalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MinfinAnalog.Domain.Interfaces;
public interface IExchangeOperationRepository : IRepository<UserExchangeOperation>
{
    decimal GetExchangeBalance(int userId, int currencyId);
}

