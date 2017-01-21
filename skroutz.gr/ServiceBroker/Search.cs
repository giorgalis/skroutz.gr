using Newtonsoft.Json;
using skroutz.gr.Entities;
using System;
using System.Text;
using System.Threading.Tasks;

namespace skroutz.gr.ServiceBroker
{
    /// <summary>
    /// Provides methods for performing search queries.
    /// </summary>
    public class Search : Request
    {
        private readonly StringBuilder _builder;
        private readonly string _accessToken;

        /// <summary>
        /// Initializes a new instance of the <see cref="Search" /> class
        /// </summary>
        /// <param name="accessToken">The access token provided by the OAuth2.0 protocol</param>
        public Search(string accessToken)
        {
            _accessToken = accessToken;
            _builder = new StringBuilder();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Search" /> class
        /// </summary>
        /// <param name="accessToken">The access token provided by the OAuth2.0 protocol</param>
        /// <param name="stringBuilder">The string builder to write to.</param>
        public Search(string accessToken, StringBuilder stringBuilder)
        {
            _accessToken = accessToken;
            _builder = stringBuilder;
        }

        /// <summary>
        /// Performs search on a given string
        /// </summary>
        /// <param name="searchString">The string to search.</param>
        /// <returns>Task&lt;RootSearch&gt;.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="searchString" /> is null or empty.</exception>
        public Task<RootSearch> SearchQuery(string searchString)
        {
            if (string.IsNullOrEmpty(searchString)) throw new ArgumentNullException(nameof(searchString));
            
            _builder.Clear();
            _builder.Append($"search?q={searchString}");
            _builder.Append($"&oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<RootSearch>(t.Result.ToString()));
        }

        /// <summary>
        /// Autocompletes the specified search string.
        /// </summary>
        /// <param name="searchString">The search string.</param>
        /// <returns>Task&lt;RootSearch&gt;.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="searchString" /> is null or empty.</exception>
        /// <remarks>Note that the results of the autocomplete are to be treated as search suggestions. When the user selects any of them you should perform a search with the selected keyphrase.</remarks>
        public Task<RootSearch> Autocomplete(string searchString)
        {
            if (string.IsNullOrEmpty(searchString)) throw new ArgumentNullException(nameof(searchString));

            _builder.Clear();
            _builder.Append($"autocomplete?q={searchString}");
            _builder.Append($"&oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<RootSearch>(t.Result.ToString()));
        }
    }
}
