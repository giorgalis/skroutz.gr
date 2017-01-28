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
    /// Provides methods for grouping a collection of filters such as Price, Keyword and other.
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
        /// The access token
        /// </summary>
        private readonly SkroutzRequest _skroutzRequest;

        /// <summary>
        /// Initializes a new instance of the <see cref="FilterGroup" /> class
        /// </summary>
        /// <param name="skroutzRequest">The access token provided by the OAuth2.0 protocol</param>
        public FilterGroup(SkroutzRequest skroutzRequest)
        {
            _skroutzRequest = skroutzRequest;
            _skroutzRequest.SBuilder = new StringBuilder();
        }

        /// <summary>
        /// List FilterGroups
        /// </summary>
        /// <param name="categoryId">The category identifier.</param>
        /// <param name="page">The page.</param>
        /// <param name="per">Results per page.</param>
        /// <param name="sparseFields">Sparse fields are a way for clients to request specific json fields from the server response.</param>
        /// <returns>Task&lt;FilterGroups&gt;.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="categoryId" /> or <paramref name="page" /> or <paramref name="per" /> is less than or equal to 0.</exception>
        /// <see href="https://developer.skroutz.gr/api/v3/filter_groups/#list-filtergroups" />
        public Task<FilterGroups> ListFilterGroups(int categoryId, int page = 1, int per = 25, params Expression<Func<Entities.Base.FilterGroup, object>>[] sparseFields)
        {
            if (categoryId <= 0) throw new ArgumentOutOfRangeException(nameof(categoryId));
            if (page <= 0) throw new ArgumentOutOfRangeException(nameof(page));
            if (per <= 0) throw new ArgumentOutOfRangeException(nameof(per));

            _skroutzRequest.SBuilder.Clear();
            _skroutzRequest.SBuilder.Append($"categories/{categoryId}/filter_groups?");
            _skroutzRequest.SBuilder.Append($"page={page}&per={per}");

            if (sparseFields.Length > 0)
                _skroutzRequest.SBuilder.Append($"&fields[root]={NameReader.GetMemberNames(sparseFields)}");

            return GetWebResultAsync(_skroutzRequest).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<FilterGroups>(t.Result.ToString()));
        }
    }
}
