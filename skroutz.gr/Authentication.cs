using Newtonsoft.Json;
using System;

namespace skroutz.gr
{
    public class Authentication : Request
    {
        private static readonly string domain = "https://www.skroutz.gr/";
        public static string AccessToken { get; private set; }


        public struct Credentials
        {
            public string client_id;
            public string client_secret;
        }

        public Authentication()
        {

        }

        public Authentication(Credentials credentials)
        {
            if (string.IsNullOrEmpty(credentials.client_id)) throw new ArgumentNullException(nameof(credentials.client_id));
            if (string.IsNullOrEmpty(credentials.client_secret)) throw new ArgumentNullException(nameof(credentials.client_secret));

            string request = $"oauth2/token?client_id={credentials.client_id}&client_secret={credentials.client_secret}&grant_type=client_credentials&scope=public";

            //Response response = GetTokenResponce(domain, request).ContinueWith((t) =>
            //    JsonConvert.DeserializeObject<Response>(t.Result.ToString())).Result;

            //AccessToken = response.access_token;
            AccessToken = "token";
        }

        private class Response
        {
            public string access_token { get; set; }
            public string token_type { get; set; }
            public int expires_in { get; set; }
        }
    }
}
