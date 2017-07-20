using System;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Aire.Integration.Test
{
    /// <summary>
    /// This is very simple interation test for the "homework" service
    /// <para>This test just checks the connectivity</para>
    /// <para>calling both endpoints.</para>
    /// <para>Data validation checks were done in unit tests.</para>
    /// </summary>
    class Program
    {
        private static HttpClient _client = new HttpClient();
        static void Main(string[] args)
        {
            RunConnectivityTestAsync().Wait();
            Console.ReadLine();
        }

        private static async Task RunConnectivityTestAsync()
        {
            _client.BaseAddress = ReadConfig("uri");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            Console.WriteLine("Calling post:");
            string postResult = await PostApplicationAsync(_client);
            Console.WriteLine(postResult);
            Console.WriteLine("Calling get:");
            string getResult = await GetEventsAsync(_client);
            Console.WriteLine(getResult);
        }

        private static async Task<string> GetEventsAsync(HttpClient client)
        {
            try
            {
                var response = await client.GetAsync("events");
                return await ProcessResponseAsync(response);
            }
            catch (Exception)
            {
                return $"Make sure the service is running.";
            }
        }

        private async static Task<string> PostApplicationAsync(HttpClient client)
        {
            try
            {
                // do not care about actual data at this point, just 
                // checking connectivity.
                var content = new StringContent("[{}]", Encoding.UTF8, "application/json");
                var response = await client.PostAsync("apps", content);
                return await ProcessResponseAsync(response);
            }
            catch (Exception)
            {
                return $"Make sure the service is running.";
            }
        }

        private static async Task<string> ProcessResponseAsync(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return $"{response.StatusCode}: {data}";
            }

            return $"{response.StatusCode}";
        }

        private static Uri ReadConfig(string key)
            => new Uri(ConfigurationManager.AppSettings[key] ?? string.Empty);
    }
}
