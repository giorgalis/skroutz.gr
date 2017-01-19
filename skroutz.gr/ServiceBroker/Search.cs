using Newtonsoft.Json;
using skroutz.gr.Entities;
using System;
using System.Text;
using System.Threading.Tasks;

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

        /// <summary>
        /// Searches the query.
        /// </summary>
        /// <param name="searchString">The search string.</param>
        /// <returns>Task&lt;Categories&gt;.</returns>
        /// <exception cref="System.ArgumentNullException">searchString</exception>
        public Task<RootSearch> SearchQuery(string searchString)
        {
            if (string.IsNullOrEmpty(searchString)) throw new ArgumentNullException(nameof(searchString));
            
            _builder.Clear();
            _builder.Append($"search?q={searchString}");
            _builder.Append($"&oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<RootSearch>(t.Result.ToString()));
        }
    }
}
