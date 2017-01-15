using System.Text;

namespace skroutz.gr.ServiceBroker
{
    /// <summary>
    /// Search
    /// </summary>
    public class Search : Request
    {
        private readonly StringBuilder _builder;
        private readonly string _accessToken;

        /// <summary>
        /// Initializes a new instance of the Search class
        /// </summary>
        /// <param name="accessToken">The access token provided by the OAuth2.0 protocol</param>
        public Search(string accessToken)
        {
            _accessToken = accessToken;
            _builder = new StringBuilder();
        }

        /// <summary>
        /// Initializes a new instance of the Search class
        /// </summary>
        /// <param name="accessToken">The access token provided by the OAuth2.0 protocol</param>
        /// <param name="stringBuilder">The string builder to write to.</param>
        public Search(string accessToken, StringBuilder stringBuilder)
        {
            _accessToken = accessToken;
            _builder = stringBuilder;
        }
    }
}
