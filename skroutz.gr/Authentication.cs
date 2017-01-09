using Newtonsoft.Json;
using System;

namespace skroutz.gr
{
    public class Authentication : Request
    {
        private static readonly string domain = "https://www.skroutz.gr/";
        public string ApplicationToken { get; private set; }
        public string UserToken { get; private set; }


        public struct AppCredentials
        {
            public string client_id;
            public string client_secret;
        }

        public struct UserCredentials
        {
            public string client_id;
            public string redirect_uri;
        }

        /// <summary>
        /// Initializes a new instance of the Authentication class
        /// </summary>
        /// <param name="credentials"></param>
        public Authentication(AppCredentials credentials)
        {
            if (string.IsNullOrEmpty(credentials.client_id)) throw new ArgumentNullException(nameof(credentials.client_id));
            if (string.IsNullOrEmpty(credentials.client_secret)) throw new ArgumentNullException(nameof(credentials.client_secret));

            string request = Uri.EscapeDataString($"oauth2/token?client_id={credentials.client_id}&client_secret={credentials.client_secret}&grant_type=client_credentials&scope=public");

            AppResponse response = GetWebResultAsync(domain, request).ContinueWith((t) =>
                JsonConvert.DeserializeObject<AppResponse>(t.Result.ToString())).Result;

            this.ApplicationToken = response.access_token;
        }

        /// <summary>
        /// Initializes a new instance of the Authentication class
        /// </summary>
        /// <param name="credentials"></param>
        public Authentication(UserCredentials credentials)
        {
            if (string.IsNullOrEmpty(credentials.client_id)) throw new ArgumentNullException(nameof(credentials.client_id));
            if (string.IsNullOrEmpty(credentials.redirect_uri)) throw new ArgumentNullException(nameof(credentials.redirect_uri));

            string request = $"oauth2/authorizations/new?client_id={credentials.client_id}&redirect_uri={credentials.redirect_uri}&response_type=code&scope=public,favorites,notifications";

            //Response response = GetTokenResponse(domain, request).ContinueWith((t) =>
            //    JsonConvert.DeserializeObject<Response>(t.Result.ToString())).Result;

            //AccessToken = response.access_token;
            this.UserToken = "usertoken";
        }

        private class AppResponse
        {
            public string access_token { get; set; }
            public string token_type { get; set; }
            public int expires_in { get; set; }
        }

        private class UserResponse : AppResponse
        {
            public string refresh_token { get; set; }
        }
    }
}
