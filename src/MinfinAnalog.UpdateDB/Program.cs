using System;
using System.Collections.Generic;
using MinfinAnalog.Infrastructure;
using MinfinAnalog.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Text.Json;
using System.Diagnostics;

namespace MinfinAnalog.UpdateDB
{
    class Program
    {
        private static readonly DateTime startDate = new DateTime(1996, 01, 06);
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            try
            {
                using (HttpClient apiClient = new HttpClient())
                {
                    var date = startDate;
                    Stopwatch sw = new Stopwatch();
                    sw.Reset();
                    sw.Start();
                    var nbuCurrencyJson = GetNbuCurrencyJson(date, apiClient);
                    var nbuCurrencyList = DeserializeJson(nbuCurrencyJson);

                    using (var context = new MinfinAnalogContext(BuildDbContextOptions()))
                    {
                        AddCurrencies(nbuCurrencyList, context);

                        var currencyIdByCode = context.Сurrencies.ToDictionary(c => c.CurrencyCode, c => c.Id);

                        sw.Stop();
                        AddCurrencyRates(nbuCurrencyList, currencyIdByCode, context);
                        Console.WriteLine($"Done. => {date}. Time elapsed (ms): {sw.ElapsedMilliseconds}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.ReadLine();
        }

        private static void AddCurrencyRates(List<NbuCurrencyRate> nbuCurrencyList, Dictionary<string, int> currencyIdByCode, MinfinAnalogContext context)
        {
            if (nbuCurrencyList.Count > 0 && nbuCurrencyList[0].ExchangeDate > GetCurrencyRatesMaxDate(context))
            {
                foreach (var nbuCurrency in nbuCurrencyList)
                {
                    context.CurrencyRates.Add(new CurrencyRate
                    {
                        CurrencyId = currencyIdByCode[nbuCurrency.CurrencyCode],
                        ExchangeDate = nbuCurrency.ExchangeDate,
                        Rate = nbuCurrency.Rate
                    });
                    context.SaveChanges();
                }
            }
        }

        private static DateTime GetCurrencyRatesMaxDate(MinfinAnalogContext context)
        {
            return context.CurrencyRates
                .OrderByDescending(cr => cr.ExchangeDate)
                .Select(cr => cr.ExchangeDate)
                .FirstOrDefault();
        }

        private static void AddCurrencies(List<NbuCurrencyRate> nbuCurrencyList, MinfinAnalogContext context)
        {
            foreach (var nbuCurrency in nbuCurrencyList)
            {
                if (!context.Сurrencies.Any(c => c.CurrencyCode == nbuCurrency.CurrencyCode))
                {
                    context.Сurrencies.Add(new Currency
                    {
                        CurrencyCode = nbuCurrency.CurrencyCode,
                        Name = nbuCurrency.CurrencyName
                    });

                }
            }
            context.SaveChanges();
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

        private static string GetNbuCurrencyJson(DateTime date, HttpClient client)
        {
            var dateFormated = date.ToString("yyyyMMdd");
            var nbuCurrencyUrl = $"https://bank.gov.ua/NBUStatService/v1/statdirectory/exchangenew?json&date={dateFormated}";
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return LoadJsonData(nbuCurrencyUrl, client).GetAwaiter().GetResult();
        }

        private static List<NbuCurrencyRate> DeserializeJson(string nbuCurrencyJson)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new CustomDateTimeConverter());
            return JsonSerializer.Deserialize<List<NbuCurrencyRate>>(nbuCurrencyJson, options);
        }

        public static async Task<string> LoadJsonData(string url, HttpClient apiClient)
        {
            using HttpResponseMessage response = await apiClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }
    }
}
