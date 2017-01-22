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
        /// The client Id you received from skroutz api team.
        /// </summary>
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        /// <summary>
        /// The client secret you received from skroutz api team.
        /// </summary>
        [JsonProperty("client_secret")]
        public string ClientSecret { get; set; }
    }


    /// <summary>
    /// Struct UserCredentials
    /// </summary>
    public struct UserCredentials 
    {
        /// <summary>
        /// The client Id you received from skroutz api team.
        /// </summary>
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        /// <summary>
        /// The URL in your application where users will be sent after authorization.
        /// </summary>
        [JsonProperty("redirect_uri")]
        public string RedirectUri { get; set; }
    }


    /// <summary>
    /// Class Authorization.
    /// </summary>
    public class Authorization : Request
    {

        /// <summary>
        /// Gets the application response.
        /// </summary>
        /// <value>The application response.</value>
        public AppResponse AppResponse { get; private set; }

        /// <summary>
        /// Gets the response.
        /// </summary>
        /// <value>The response.</value>
        //public UserResponse UserResponse { get; private set; }

        public SkroutzRequest skroutzRequest { get; private set; } = new SkroutzRequest();

        /// <summary>
        /// Initializes a new instance of the <see cref="Authorization" /> class.
        /// </summary>
        /// <param name="credentials">The credentials.</param>
        /// <exception cref="ArgumentNullException">Thrown when <see cref="AppCredentials.ClientId"/> or <see cref="AppCredentials.ClientSecret"/> is null or empty.</exception>
        public Authorization(AppCredentials credentials)
        {
            if (string.IsNullOrEmpty(credentials.ClientId)) throw new ArgumentNullException(nameof(credentials.ClientId));
            if (string.IsNullOrEmpty(credentials.ClientSecret)) throw new ArgumentNullException(nameof(credentials.ClientSecret));

            string request = $"oauth2/token?client_id={credentials.ClientId}&client_secret={credentials.ClientSecret}&grant_type=client_credentials&scope=public";

            AppResponse appResponse = PostWebResultAsync(request).ContinueWith((t) =>
                JsonConvert.DeserializeObject<AppResponse>(t.Result.ToString())).Result;

            this.skroutzRequest.AccessToken = appResponse.AccessToken;
            this.skroutzRequest.TokenType = appResponse.TokenType;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Authorization" /> class.
        /// </summary>
        /// <param name="credentials">The credentials.</param>
        /// <exception cref="ArgumentNullException">Thrown when <see cref="UserCredentials.ClientId"/> or <see cref="UserCredentials.RedirectUri"/> is null or empty.</exception>
        public Authorization(UserCredentials credentials)
        {
            if (string.IsNullOrEmpty(credentials.ClientId)) throw new ArgumentNullException(nameof(credentials.ClientId));
            if (string.IsNullOrEmpty(credentials.RedirectUri)) throw new ArgumentNullException(nameof(credentials.RedirectUri));

            string request = $"oauth2/authorizations/new?client_id={credentials.ClientId}&redirect_uri={credentials.RedirectUri}&response_type=code&scope=public,favorites,notifications";

            UserResponse userResponse = PostWebResultAsync(request).ContinueWith((t) =>
                JsonConvert.DeserializeObject<UserResponse>(t.Result.ToString())).Result;

            this.skroutzRequest.AccessToken = userResponse.AccessToken;
            this.skroutzRequest.TokenType = userResponse.TokenType;
        }
    }


    /// <summary>
    /// Class AppResponse.
    /// </summary>
    public class AppResponse
    {
        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        /// <value>The access token.</value>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        /// <summary>
        /// Gets or sets the type of the token.
        /// </summary>
        /// <value>The type of the token.</value>
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
        /// <summary>
        /// Gets or sets the expires in.
        /// </summary>
        /// <value>The expires in. (seconds).</value>
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
    }

    /// <summary>
    /// Class UserResponse.
    /// </summary>
    /// <seealso cref="Authorization.AppResponse" />
    public class UserResponse : AppResponse
    {
        /// <summary>
        /// Gets or sets the refresh token.
        /// </summary>
        /// <value>The refresh token.</value>
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
    }
}
