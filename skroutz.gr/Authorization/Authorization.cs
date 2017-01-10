using Newtonsoft.Json;
using System;

namespace skroutz.gr.Authorization
{
    /// <summary>
    /// Application Credentials
    /// </summary>
    public struct AppCredentials
    {
        /// <summary>
        /// The client Id you received from skroutz api team
        /// </summary>
        public string client_id;

        /// <summary>
        /// The client secret you received from skroutz api team
        /// </summary>
        public string client_secret;
    }

    /// <summary>
    /// User Credentials
    /// </summary>
    public struct UserCredentials
    {
        /// <summary>
        /// The client Id you received from skroutz api team
        /// </summary>
        public string client_id;

        /// <summary>
        /// The URL in your application where users will be sent after authorization.
        /// </summary>
        public string redirect_uri;
    }

    /// <summary>
    /// Authentication
    /// </summary>
    public class Authorization : Request
    {
        private static readonly string domain = "https://www.skroutz.gr/";

        /// <summary>
        /// Application Token
        /// </summary>
        public string ApplicationToken { get; private set; }

        /// <summary>
        /// User Token
        /// </summary>
        public string UserToken { get; private set; }

        /// <summary>
        /// Initializes a new instance of the Authorization class
        /// </summary>
        /// <param name="credentials"></param>
        public Authorization(AppCredentials credentials)
        {
            if (string.IsNullOrEmpty(credentials.client_id)) throw new ArgumentNullException(nameof(credentials.client_id));
            if (string.IsNullOrEmpty(credentials.client_secret)) throw new ArgumentNullException(nameof(credentials.client_secret));

            string request = $"oauth2/token?client_id={credentials.client_id}&client_secret={credentials.client_secret}&grant_type=client_credentials&scope=public";

            AppResponse response = GetWebResultAsync(domain, request).ContinueWith((t) =>
                JsonConvert.DeserializeObject<AppResponse>(t.Result.ToString())).Result;

            this.ApplicationToken = response.access_token;
        }

        /// <summary>
        /// Initializes a new instance of the Authorization class
        /// </summary>
        /// <param name="credentials"></param>
        public Authorization(UserCredentials credentials)
        {
            if (string.IsNullOrEmpty(credentials.client_id)) throw new ArgumentNullException(nameof(credentials.client_id));
            if (string.IsNullOrEmpty(credentials.redirect_uri)) throw new ArgumentNullException(nameof(credentials.redirect_uri));

            string request = $"oauth2/authorizations/new?client_id={credentials.client_id}&redirect_uri={credentials.redirect_uri}&response_type=code&scope=public,favorites,notifications";

            UserResponse response = GetWebResultAsync(domain, request).ContinueWith((t) =>
                JsonConvert.DeserializeObject<UserResponse>(t.Result.ToString())).Result;

            this.UserToken = response.access_token;
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
