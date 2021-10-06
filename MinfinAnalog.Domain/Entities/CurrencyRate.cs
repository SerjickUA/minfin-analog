using System;
using System.Collections.Generic;
using System.Text;

namespace MinfinAnalog.Domain.Model
{
    public class CurrencyRate
    {
        public int Id { get; set; }
        public DateTime ExchangeDate { get; set; }
        public int CurencyId { get; set; }
        public decimal? Rate { get; set; }
        public virtual Сurrency Curency { get; set; }

    }
}
