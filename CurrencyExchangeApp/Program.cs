using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CurrencyExchangeApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Write("Enter a currency code (e.g., USD, EUR, GBP): ");
            string currency = Console.ReadLine();

            await GetExchangeRate(currency);
        }

        static async Task GetExchangeRate(string currency)
        {
            string apiKey = "0f19ad1a00d1b9039b09881277b5d0e2"; // Replace with your ExchangeRate-API key
            string apiUrl = $"https://v6.exchangerate-api.com/v6/{apiKey}/latest/{currency}";

            using (HttpClient client = new HttpClient())
            {
                string json = await client.GetStringAsync(apiUrl);
                JObject obj = JObject.Parse(json);

                string baseCurrency = (string)obj["base_code"];
                JObject rates = (JObject)obj["conversion_rates"];

                Console.WriteLine($"Exchange rates for {baseCurrency}:");

                foreach (var rate in rates)
                {
                    Console.WriteLine($"{rate.Key}: {rate.Value}");
                }
            }
        }
    }
}
