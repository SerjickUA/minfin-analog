using System;
using System.Collections.Generic;
using System.Text;
using MinfinAnalog.Data.Entities;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MinfinAnalog.UpdateDB
{
    public class NbuCurrencyRate
    {
        [JsonPropertyName("txt")]
        public string CurrencyName { get; set; }
        [JsonPropertyName("exchangedate")]
        public DateTime ExchangeDate { get; set; }
        [JsonPropertyName("rate")]
        public decimal Rate { get; set; }
        [JsonPropertyName("cc")]
        public string CurrencyCode { get; set; }

    }
}
