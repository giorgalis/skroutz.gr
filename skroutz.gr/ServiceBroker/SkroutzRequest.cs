using skroutz.gr.Authorization;
using System;
using System.Text;

namespace skroutz.gr.ServiceBroker
{
    /// <summary>
    /// Enum HttpMethod
    /// </summary>
    public enum HttpMethod
    {
        /// <summary>
        /// Represents an HTTP DELETE protocol method.
        /// </summary>
        DELETE,

        /// <summary>
        /// Represents an HTTP GET protocol method.
        /// </summary>
        GET,

        /// <summary>
        /// Represents an HTTP HEAD protocol method. The HEAD method is identical to GET except that the server only returns message-headers in the response, without a message-body.
        /// </summary>
        HEAD,

        /// <summary>
        /// Represents an HTTP POST protocol method that is used to post a new entity as an addition to a URI.
        /// </summary>
        POST,

        /// <summary>
        /// Represents an HTTP PUT protocol method that is used to replace an entity identified by a URI.
        /// </summary>
        PUT,

        /// <summary>
        /// Represents an HTTP TRACE protocol method.
        /// </summary>
        TRACE
    }

    /// <summary>
    /// Class SkroutzRequest.
    /// </summary>
    public class SkroutzRequest
    {
        /// <summary>
        /// The Domain end point
        /// </summary>
        public readonly string DomainEndPoint = "https://www.skroutz.gr/";

        /// <summary>
        /// The API end point
        /// </summary>
        public readonly string ApiEndPoint = "https://api.skroutz.gr/";

        /// <summary>
        /// Gets or sets the API version.
        /// </summary>
        /// <value>The API version.</value>
        public string ApiVersion { get; set; } = "3.1";

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
        public HttpMethod Method { get; set; } = HttpMethod.GET;

        /// <summary>
        /// Gets or sets the postdata.
        /// </summary>
        /// <value>The postdata.</value>
        public string Postdata { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SkroutzRequest" /> class
        /// </summary>
        /// <param name="credentials"></param>
        /// <param name="apiVersion"></param>
        public SkroutzRequest(Credentials credentials, string apiVersion = null)
        {
            if (string.IsNullOrEmpty(credentials.ClientId)) throw new ArgumentNullException(nameof(credentials.ClientId));
            if (string.IsNullOrEmpty(credentials.ClientSecret)) throw new ArgumentNullException(nameof(credentials.ClientSecret));

            if (!string.IsNullOrEmpty(apiVersion)) this.ApiVersion = apiVersion;

            Authorization.Authorization authorization = new Authorization.Authorization(this, credentials);
            this.AuthResponse = authorization.AuthResponse;

            this.SBuilder = new StringBuilder();

            this.Method = HttpMethod.GET;
            this.Postdata = "";
        }
    }
}
