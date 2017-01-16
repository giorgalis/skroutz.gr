using Newtonsoft.Json;
using skroutz.gr.ServiceBroker;
using System;

namespace skroutz.gr.Authorization
{

    /// <summary>
    /// Struct AppCredentials
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
    /// Struct UserCredentials
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
    /// Class Authorization.
    /// </summary>
    /// <seealso cref="Request" />
    public class Authorization : Request
    {
        /// <summary>
        /// Application Token
        /// </summary>
        /// <value>The application token.</value>
        public string ApplicationToken { get; private set; }

        /// <summary>
        /// User Token
        /// </summary>
        /// <value>The user token.</value>
        public string UserToken { get; private set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="Authorization" /> class.
        /// </summary>
        /// <param name="credentials">The credentials.</param>
        /// <exception cref="ArgumentNullException">client_id
        /// or
        /// client_secret</exception>
        public Authorization(AppCredentials credentials)
        {
            if (string.IsNullOrEmpty(credentials.client_id)) throw new ArgumentNullException(nameof(credentials.client_id));
            if (string.IsNullOrEmpty(credentials.client_secret)) throw new ArgumentNullException(nameof(credentials.client_secret));

            string request = $"oauth2/token?client_id={credentials.client_id}&client_secret={credentials.client_secret}&grant_type=client_credentials&scope=public";

            AppResponse response = PostWebResultAsync(request).ContinueWith((t) =>
                JsonConvert.DeserializeObject<AppResponse>(t.Result.ToString())).Result;

            this.ApplicationToken = response.access_token;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Authorization" /> class.
        /// </summary>
        /// <param name="credentials">The credentials.</param>
        /// <exception cref="ArgumentNullException">client_id
        /// or
        /// redirect_uri</exception>
        public Authorization(UserCredentials credentials)
        {
            if (string.IsNullOrEmpty(credentials.client_id)) throw new ArgumentNullException(nameof(credentials.client_id));
            if (string.IsNullOrEmpty(credentials.redirect_uri)) throw new ArgumentNullException(nameof(credentials.redirect_uri));

            string request = $"oauth2/authorizations/new?client_id={credentials.client_id}&redirect_uri={credentials.redirect_uri}&response_type=code&scope=public,favorites,notifications";

            UserResponse response = PostWebResultAsync(request).ContinueWith((t) =>
                JsonConvert.DeserializeObject<UserResponse>(t.Result.ToString())).Result;

            this.UserToken = response.access_token;
        }

        /// <summary>
        /// Class AppResponse.
        /// </summary>
        private class AppResponse
        {
            /// <summary>
            /// Gets or sets the access token.
            /// </summary>
            /// <value>The access token.</value>
            public string access_token { get; set; }
            /// <summary>
            /// Gets or sets the type of the token.
            /// </summary>
            /// <value>The type of the token.</value>
            public string token_type { get; set; }
            /// <summary>
            /// Gets or sets the expires in.
            /// </summary>
            /// <value>The expires in.</value>
            public int expires_in { get; set; }
        }

        /// <summary>
        /// Class UserResponse.
        /// </summary>
        /// <seealso cref="Authorization.AppResponse" />
        private class UserResponse : AppResponse
        {
            /// <summary>
            /// Gets or sets the refresh token.
            /// </summary>
            /// <value>The refresh token.</value>
            public string refresh_token { get; set; }
        }
    }
}
