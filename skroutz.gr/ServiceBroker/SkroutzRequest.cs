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
        /// <summary>
        /// The domain
        /// </summary>
        public const string Domain = "https://www.skroutz.gr/";
        /// <summary>
        /// The API end point
        /// </summary>
        public const string ApiEndPoint = "https://api.skroutz.gr/";
        /// <summary>
        /// Gets or sets the API version.
        /// </summary>
        /// <value>The API version.</value>
        public string ApiVersion { get; set; } = "3.0";

        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        /// <value>The access token.</value>
        public string AccessToken { get; set; }


        /// <summary>
        /// The token type
        /// </summary>
        private string _tokenType;

        /// <summary>
        /// Gets or sets the type of the token.
        /// </summary>
        /// <value>The type of the token.</value>
        public string TokenType
        {
            get { return _tokenType; }
            set { _tokenType = ToTitleCase(value.ToLower()); }
        }

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

        /// <summary>
        /// To the title case.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns>System.String.</returns>
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
