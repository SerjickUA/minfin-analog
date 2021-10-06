﻿using System.Collections.Generic;

namespace MinfinAnalog.Domain.Entities
{
    public class Сurrency
    {
        public Сurrency()
        {
            CurrencyRates = new HashSet<CurrencyRate>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string CurrencyCode { get; set; }
        public virtual ICollection<CurrencyRate> CurrencyRates { get; set; }
    }
}