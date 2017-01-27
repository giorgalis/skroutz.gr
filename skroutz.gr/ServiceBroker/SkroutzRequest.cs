using skroutz.gr.Authorization;

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
    public class SkroutzRequest : Request
    {
        /// <summary>
        /// The domain
        /// </summary>
        public string Domain { get; private set; } = "https://www.skroutz.gr/";
        /// <summary>
        /// The API end point
        /// </summary>
        public string ApiEndPoint { get; private set; } = "https://api.skroutz.gr/";
        /// <summary>
        /// Gets or sets the API version.
        /// </summary>
        /// <value>The API version.</value>
        public string ApiVersion { get; set; } = "3.0";

        /// <summary>
        /// Gets or sets the authentication response.
        /// </summary>
        /// <value>The authentication response.</value>
        public AuthResponse AuthResponse { get; set; }

        public RateLimiting RateLimiting { get; set; }

        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        /// <value>The path.</value>
        public string Path { get; set; }

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
