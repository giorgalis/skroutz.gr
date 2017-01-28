using skroutz.gr.Authorization;
using System;
using System.Text;

namespace skroutz.gr.ServiceBroker
{
    /// <summary>
    /// Enum Method
    /// </summary>
    public enum Method
    {
        /// <summary>
        /// The get
        /// </summary>
        GET,
        /// <summary>
        /// The post
        /// </summary>
        POST
    }

    /// <summary>
    /// Class SkroutzRequest.
    /// </summary>
    public class SkroutzRequest
    {
        public SkroutzRequest(Credentials credentials)
        {
            if (string.IsNullOrEmpty(credentials.ClientId)) throw new ArgumentNullException(nameof(credentials.ClientId));
            if (string.IsNullOrEmpty(credentials.ClientSecret)) throw new ArgumentNullException(nameof(credentials.ClientSecret));

            Authorization.Authorization authorization = new Authorization.Authorization(credentials);
            this.AuthResponse = authorization.AuthResponse;

            this.SBuilder = new StringBuilder();
        }
        /// <summary>
        /// The domain
        /// </summary>
        public string Domain { get; set; } = "https://www.skroutz.gr/";
        /// <summary>
        /// The API end point
        /// </summary>
        public string ApiEndPoint { get; set; } = "https://api.skroutz.gr/";
        /// <summary>
        /// Gets or sets the API version.
        /// </summary>
        /// <value>The API version.</value>
        public string ApiVersion { get; set; } = "3.0";

        /// <summary>
        /// Gets or sets the StringBuilder.
        /// </summary>
        /// <value>The StringBuilder.</value>
        public StringBuilder SBuilder { get; set; }

        /// <summary>
        /// Gets or sets the authentication response.
        /// </summary>
        /// <value>The authentication response.</value>
        public AuthResponse AuthResponse { get; set; }

        /// <summary>
        /// Gets or sets the RateLimiting
        /// </summary>
        /// <value>The RateLimiting.</value>
        public RateLimiting RateLimiting { get; set; }

        private string _Path;

        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        /// <value>The path.</value>
        public string Path
        {
            get { return SBuilder.ToString(); }
            set { _Path = value; }
        }

        /// <summary>
        /// Gets or sets the method.
        /// </summary>
        /// <value>The method.</value>
        public Method Method { get; set; } = Method.GET;

        /// <summary>
        /// Gets or sets the postdata.
        /// </summary>
        /// <value>The postdata.</value>
        public string Postdata { get; set; }
    }

 
}
