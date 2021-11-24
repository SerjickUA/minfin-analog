using System;
using System.Collections.Generic;
using System.Text;

namespace MinfinAnalog.Data.Entities;
public class CurrencyRate
{
    public int Id { get; set; }
    public DateTime ExchangeDate { get; set; }
    public int CurrencyId { get; set; }
    public decimal Rate { get; set; }

}

