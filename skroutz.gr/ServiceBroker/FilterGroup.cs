using Newtonsoft.Json;
using skroutz.gr.Entities;
using System;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace skroutz.gr.ServiceBroker
{
    /// <summary>
    /// Provides methods for grouping a collection of filters.
    /// <list type="bullet">
    /// <item>
    /// <description>Price</description>
    /// </item>
    /// <item>
    /// <description>Keyword</description>
    /// </item>
    /// <item>
    /// <description>Spec</description>
    /// </item>
    /// <item>
    /// <description>SyncedSpec</description>
    /// </item>
    /// <item>
    /// <description>CustomRange</description>
    /// </item>
    /// <item>
    /// <description>Sizes</description>
    /// </item>
    /// </list>
    /// </summary>
    /// <remarks>A Filter Group is a collection of filters of the same kind.</remarks>
    public class FilterGroup : Request
    {
        /// <summary>
        /// The builder
        /// </summary>
        private readonly StringBuilder _builder;
        /// <summary>
        /// The access token
        /// </summary>
        private readonly string _accessToken;

        /// <summary>
        /// Initializes a new instance of the <see cref="FilterGroup" /> class
        /// </summary>
        /// <param name="accessToken">The access token provided by the OAuth2.0 protocol</param>
        public FilterGroup(string accessToken)
        {
            _accessToken = accessToken;
            _builder = new StringBuilder();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FilterGroup" /> class
        /// </summary>
        /// <param name="accessToken">The access token provided by the OAuth2.0 protocol</param>
        /// <param name="stringBuilder">The string builder to write to.</param>
        public FilterGroup(string accessToken, StringBuilder stringBuilder)
        {
            _accessToken = accessToken;
            _builder = stringBuilder;
        }

        /// <summary>
        /// List FilterGroups
        /// </summary>
        /// <param name="categoryId">The category identifier.</param>
        /// <param name="page">The page.</param>
        /// <param name="per">Results per page.</param>
        /// <param name="sparseFields">The sparse fields.</param>
        /// <returns>Task&lt;FilterGroups&gt;.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="categoryId" /> or <paramref name="page" /> or <paramref name="per" /> is less than or equal to 0.</exception>
        /// <see href="https://developer.skroutz.gr/api/v3/filter_groups/#list-filtergroups" />
        public Task<FilterGroups> ListFilterGroups(int categoryId, int page = 1, int per = 25, params Expression<Func<Entities.Base.FilterGroup, object>>[] sparseFields)
        {
            if (categoryId <= 0) throw new ArgumentOutOfRangeException(nameof(categoryId));
            if (page <= 0) throw new ArgumentOutOfRangeException(nameof(page));
            if (per <= 0) throw new ArgumentOutOfRangeException(nameof(per));

            _builder.Clear();
            _builder.Append($"categories/{categoryId}/filter_groups?");
            _builder.Append($"oauth_token={_accessToken}");
            _builder.Append($"&page={page}&per={per}");

            if (sparseFields != null)
                _builder.Append($"&fields[root]={NameReader.GetMemberNames(sparseFields)}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<FilterGroups>(t.Result.ToString()));
        }
    }
}
