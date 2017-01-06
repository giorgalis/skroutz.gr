using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace skroutz.gr
{
    public class Request
    {
        private const string ApiVersion = "3.0";
        private static readonly string Domain = $"http://api.skroutz.gr/";
        private string AuthToken { get; set; }

        public Task<string> GetWebResultAsync(string value)
        {
            HttpClient client = new HttpClient { BaseAddress = new Uri(Domain) };
            return client.GetStringAsync(value);
        }
    }
}