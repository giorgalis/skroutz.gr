using Newtonsoft.Json;
using skroutz.gr.Shared;

namespace skroutz.gr.Authorization
{
    /// <summary>
    /// Class AuthResponse.
    /// </summary>
    public class AuthResponse
    {
        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        /// <value>The access token.</value>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }


        private string _TokenType;
        /// <summary>
        /// Gets or sets the type of the token.
        /// </summary>
        /// <value>The type of the token.</value>
        [JsonProperty("token_type")]

        public string TokenType
        {
            get { return _TokenType; }
            set { _TokenType = value.ToTitleCase(); }
        }

        /// <summary>
        /// Gets or sets the expires in.
        /// </summary>
        /// <value>The expires in. (seconds).</value>
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
    }
}
