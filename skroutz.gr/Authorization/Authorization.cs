using Newtonsoft.Json;
using skroutz.gr.ServiceBroker;
using System;

namespace skroutz.gr.Authorization
{
    /// <summary>
    /// Struct Credentials
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
    internal class Authorization : Request
    {
        /// <summary>
        /// Gets the AuthResponse.
        /// </summary>
        /// <value>The response.</value>
        public AuthResponse AuthResponse { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Authorization" /> class.
        /// </summary>
        /// <param name="credentials">The credentials.</param>
        /// <exception cref="ArgumentNullException">Thrown when <see cref="Credentials.ClientId"/> or <see cref="Credentials.ClientSecret"/> are null or empty.</exception>
        public Authorization(SkroutzRequest skroutzRequest, Credentials credentials)
        {
            if (string.IsNullOrEmpty(credentials.ClientId)) throw new ArgumentNullException(nameof(credentials.ClientId));
            if (string.IsNullOrEmpty(credentials.ClientSecret)) throw new ArgumentNullException(nameof(credentials.ClientSecret));

            skroutzRequest.Method = HttpMethod.POST;
            skroutzRequest.PostData = $"oauth2/token?client_id={credentials.ClientId}&client_secret={credentials.ClientSecret}&grant_type=client_credentials&scope=public";
            
            this.AuthResponse = PostWebResultAsync(skroutzRequest).ContinueWith((t) =>
                 JsonConvert.DeserializeObject<AuthResponse>(t.Result.ToString())).Result;
        }
    }
}
