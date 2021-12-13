using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MinfinAnalog.Data;
using MinfinAnalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MinfinAnalog.UpdateDB
{
    class Program
    {
        private static readonly DateTime startDate = new(2021, 10, 1);
        private static readonly DateTime endDate = new(2021, 12, 12);
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            try
            {
                var dateList = GetDateList(startDate, endDate);
                using var context = new MinfinAnalogContext(BuildDbContextOptions());
                var currenciesData = await GetCurrenciesAsync();
                var currencies = new Dictionary<string, Currency>();

                foreach (var currencyData in currenciesData)
                {
                    currencies.Add(currencyData.Key,
                    new Currency()
                    {
                        CurrencyCode = currencyData.Key,
                        Name = currencyData.Value
                    });
                }

                AddCurrencies(currencies.Values.ToList(), context);

                foreach (var date in dateList)
                {
                    Stopwatch stopwatch = Stopwatch.StartNew();
                    Console.WriteLine($"Export data for {date.Year}-{date.Month:00}-{ date.Day:00}");
                    foreach (var currency in currencies)
                    {
                        var sourceCurrencyCode = currency.Key.ToString();
                        var currencyRates = await GetExchangeRatesAsync(date, sourceCurrencyCode, currencies);
                        if (currencyRates.Count > 0)
                        {
                            AddCurrencyRates(currencyRates, context);
                        }
                    }

                    stopwatch.Stop();
                    Console.WriteLine($"Time elapsed: {stopwatch.ElapsedMilliseconds} ms");
                }
                Console.WriteLine("Saving changes to database.");
                context.SaveChanges();
                Console.WriteLine("Done!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}\n{ex.StackTrace}");
                Console.WriteLine(ex.InnerException.Message);
            }

            Console.ReadLine();
        }
        /// <summary>
        /// Get currencies list from Free Currency Exchange Rates API (https://github.com/fawazahmed0/currency-api#readme)
        /// </summary>
        private static async Task<Dictionary<string, string>> GetCurrenciesAsync()
        {
            var url = $"https://cdn.jsdelivr.net/gh/fawazahmed0/currency-api@1/latest/currencies.json";
            return await GetAsync<Dictionary<string, string>>(url);
        }
        /// <summary>
        /// Get exchange rates from Free Currency Exchange Rates API  (https://github.com/fawazahmed0/currency-api#readme)
        /// </summary>
        private static async Task<List<CurrencyRate>> GetExchangeRatesAsync(DateTime date, string sourceCurrencyCode
            , Dictionary<string, Currency> currencies)
        {
            var url = $"https://cdn.jsdelivr.net/gh/fawazahmed0/currency-api@1/{date.Year}-{date.Month:00}-{date.Day:00}/currencies/{sourceCurrencyCode}.json";
            Dictionary<string, decimal> currencyRatesData = new();
            try
            {
                var data = await GetAsync<Dictionary<string, object>>(url);

                currencyRatesData = JsonSerializer.Deserialize<Dictionary<string,decimal>>(data[sourceCurrencyCode].ToString());
            }
            catch { }
            var rates = new List<CurrencyRate>();
            foreach (var dataItem in currencyRatesData)
            {

                var destinationCurrecyCode = dataItem.Key;
 
                if (currencies.ContainsKey(sourceCurrencyCode) && currencies.ContainsKey(destinationCurrecyCode))
                {
                    rates.Add(new CurrencyRate()
                    {
                        ExchangeDate = date,
                        SourceCurrency = currencies[sourceCurrencyCode],
                        DestinationCurrency = currencies[destinationCurrecyCode],
                        Rate = dataItem.Value
                    });
                }
            }
            return rates;
        }
        public static IEnumerable<DateTime> GetDateList(DateTime startDate, DateTime endDate)
        {
            return Enumerable.Range(0, (endDate - startDate).Days + 1).Select(d => startDate.AddDays(d));
        }

        public static async Task<T> GetAsync<T>(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var client = new HttpClient();
             var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.StatusCode.ToString());
            }
            var content = await response.Content.ReadAsStringAsync();
            var responseData = JsonSerializer.Deserialize<T>(content);
            return responseData;
        }

        public static async Task<T> GetFromFileAsync<T>(string filePath)
        {
            using FileStream openStream = File.OpenRead(filePath);
            return await JsonSerializer.DeserializeAsync<T>(openStream);
        }


        private static void AddCurrencyRates(List<CurrencyRate> currencyRateList, MinfinAnalogContext context)
        {
            context.CurrencyRates.AddRange(currencyRateList);
        }

        private static void AddCurrencies(List<Currency> currencies, MinfinAnalogContext context)
        {
            foreach (var currency in currencies)
            {
                if (!context.Currencies.Any(c => c.CurrencyCode == currency.CurrencyCode))
                {
                    context.Currencies.Add(currency);
                }
            }

        }
        private static DbContextOptions<MinfinAnalogContext> BuildDbContextOptions()
        {
            var configBuilder = new ConfigurationBuilder();
            var config = configBuilder
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = config.GetConnectionString("Default");

            var optionsBuilder = new DbContextOptionsBuilder<MinfinAnalogContext>();
            var dbContextOptions = optionsBuilder
                    .UseSqlServer(connectionString)
                    .Options;
            return dbContextOptions;
        }
    }
}
