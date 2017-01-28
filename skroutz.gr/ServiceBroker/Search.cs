using Newtonsoft.Json;
using skroutz.gr.Entities;
using skroutz.gr.Shared;
using System;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace skroutz.gr.ServiceBroker
{
    /// <summary>
    /// Provides methods for performing search queries.
    /// </summary>
    public class Search : Request
    {
        private readonly SkroutzRequest _skroutzRequest;

        /// <summary>
        /// Initializes a new instance of the <see cref="Category" /> class
        /// </summary>
        /// <param name="skroutzRequest">The access token provided by the OAuth2.0 protocol</param>
        public Search(SkroutzRequest skroutzRequest)
        {
            _skroutzRequest = skroutzRequest;
            _skroutzRequest.SBuilder = new StringBuilder();
        }
        
        /// <summary>
        /// Performs search on a given string
        /// </summary>
        /// <param name="searchString">The string to search.</param>
        /// <param name="sparseFields">The sparse fields.</param>
        /// <returns>Task&lt;RootSearch&gt;.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="searchString" /> is null or empty.</exception>
        public Task<RootSearch> SearchQuery(string searchString, params Expression<Func<Entities.Search, object>>[] sparseFields)
        {
            if (string.IsNullOrEmpty(searchString)) throw new ArgumentNullException(nameof(searchString));
            
            _skroutzRequest.SBuilder.Clear();
            _skroutzRequest.SBuilder.Append($"search?q={searchString}");

            if (sparseFields.Length > 0)
                _skroutzRequest.SBuilder.Append($"&fields[root]={NameReader.GetMemberNames(sparseFields)}");

            return GetWebResultAsync(_skroutzRequest).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<RootSearch>(t.Result.ToString()));
        }

        /// <summary>
        /// Autocompletes the specified search string.
        /// </summary>
        /// <param name="searchString">The search string.</param>
        /// <param name="sparseFields">The sparse fields.</param>
        /// <returns>Task&lt;RootSearch&gt;.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="searchString" /> is null or empty.</exception>
        /// <remarks>Note that the results of the autocomplete are to be treated as search suggestions. When the user selects any of them you should perform a search with the selected keyphrase.</remarks>
        public Task<RootSearch> Autocomplete(string searchString, params Expression<Func<Entities.Search, object>>[] sparseFields)
        {
            if (string.IsNullOrEmpty(searchString)) throw new ArgumentNullException(nameof(searchString));

            _skroutzRequest.SBuilder.Clear();
            _skroutzRequest.SBuilder.Append($"autocomplete?q={searchString}");

            if (sparseFields.Length > 0)
                _skroutzRequest.SBuilder.Append($"fields[root]={NameReader.GetMemberNames(sparseFields)}");

            return GetWebResultAsync(_skroutzRequest).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<RootSearch>(t.Result.ToString()));
        }
    }
}
