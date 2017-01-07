using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace skroutz.gr
{
    public class Request
    {
        private const string ApiVersion = "3.0";
        private static readonly string Domain = $"http://api.skroutz.gr/";
  
        public Task<string> GetWebResultAsync(string value)
        {
            HttpClient client = new HttpClient { BaseAddress = new Uri(Domain) };
            client.DefaultRequestHeaders.Add("Accept", $"application/vnd.skroutz+json; version={ApiVersion}");
            //client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
            return client.GetStringAsync(value);
        }

        public Task<string> GetTokenResponse(string domain, string value)
        {
            HttpClient client = new HttpClient { BaseAddress = new Uri(domain) };
            return client.GetStringAsync(value);
        }
    }
}