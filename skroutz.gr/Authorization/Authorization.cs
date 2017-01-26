using Newtonsoft.Json;
using skroutz.gr.ServiceBroker;
using System;

namespace skroutz.gr.Authorization
{
    /// <summary>
    /// Struct AppCredentials
    /// </summary>
    public struct Credentials 
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
    /// Class Authorization.
    /// </summary>
    public class Authorization : Request
    {
        /// <summary>
        /// Gets the response.
        /// </summary>
        /// <value>The response.</value>
        public SkroutzRequest SkroutzRequest { get; private set; } = new SkroutzRequest();
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Authorization" /> class.
        /// </summary>
        /// <param name="credentials">The credentials.</param>
        /// <exception cref="ArgumentNullException">Thrown when <see cref="Credentials.ClientId"/> or <see cref="Credentials.ClientSecret"/> is null or empty.</exception>
        public Authorization(Credentials credentials)
        {
            if (string.IsNullOrEmpty(credentials.ClientId)) throw new ArgumentNullException(nameof(credentials.ClientId));
            if (string.IsNullOrEmpty(credentials.ClientSecret)) throw new ArgumentNullException(nameof(credentials.ClientSecret));

            string request = $"oauth2/token?client_id={credentials.ClientId}&client_secret={credentials.ClientSecret}&grant_type=client_credentials&scope=public";
            
            this.SkroutzRequest.AuthResponse = PostWebResultAsync(request).ContinueWith((t) =>
                JsonConvert.DeserializeObject<AuthResponse>(t.Result.ToString())).Result;
        }
    }


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
            set { _TokenType = ToTitleCase(value); }
        }

        /// <summary>
        /// Gets or sets the expires in.
        /// </summary>
        /// <value>The expires in. (seconds).</value>
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
        
        string ToTitleCase(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;

            string[] textArray = s.Split(' ');

            for (int i = 0; i < textArray.Length; i++)
            {
                switch (textArray[i].Length)
                {
                    case 1:
                        break;
                    default:
                        textArray[i] = char.ToUpper(textArray[i][0]) + textArray[i].Substring(1);
                        break;
                }
            }

            return string.Join(" ", textArray);
        }
    }
}
