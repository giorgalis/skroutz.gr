using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;

namespace skroutz.gr
{
    /// <summary>
    /// A Filter Group is a collection of filters of the same kind.
    /// </summary>
    public class FilterGroup : Request
    {
        private readonly StringBuilder _builder;
        private readonly string _accessToken;

        public FilterGroup(string accessToken)
        {
            _accessToken = accessToken;
            _builder = new StringBuilder();
        }

        public FilterGroup(string accessToken, StringBuilder stringBuilder)
        {
            _accessToken = accessToken;
            _builder = stringBuilder;
        }

        /// <summary>
        /// List FilterGroups
        /// </summary>
        /// <param name="categoryId"></param>
        /// <see cref="https://developer.skroutz.gr/api/v3/filter_groups/#list-filtergroups"/>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when categoryId is less than or equal to 0</exception>
        /// <returns></returns>
        public Task<Entities.Categories.FilterGroups> ListFilterGroups(int categoryId)
        {
            if (categoryId <= 0) throw new ArgumentOutOfRangeException(nameof(categoryId));

            _builder.Clear();
            _builder.Append($"categories/{categoryId}/filter_groups");
            _builder.Append($"?&oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Entities.Categories.FilterGroups>(t.Result.ToString()));
        }
    }
}
