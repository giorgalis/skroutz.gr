using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;

namespace skroutz.gr
{
    /// <summary>
    /// A SKU (Stock Keeping Unit) is an aggregation of products.
    /// </summary>
    public class SKU : Request
    {
        private readonly StringBuilder _builder;
        private readonly string _accessToken;

        public enum order_by
        {
            pricevat,
            popularity,
            rating
        }

        public enum order_dir
        {
            asc,
            desc
        }

        public SKU(string accessToken)
        {
            _accessToken = accessToken;
            _builder = new StringBuilder();
        }

        public SKU(string accessToken, StringBuilder stringBuilder)
        {
            _accessToken = accessToken;
            _builder = stringBuilder;
        }

        /// <summary>
        /// List SKUs of specific category
        /// </summary>
        /// <param name="categoryId">Unique identifier of the Category</param>
        /// <param name="orderBy">Order by price, popularity or rating</param>
        /// <param name="orderDir">Order ascending or descending</param>
        /// <see cref="https://developer.skroutz.gr/api/v3/sku/#list-skus-of-specific-category"/>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when categoryId is less than or equal to 0</exception>
        public Task<Entities.SKUs.SKUs> ListSKUsOfSpecificCategory(int categoryId, order_by orderBy = order_by.pricevat, order_dir orderDir = order_dir.asc)
        {
            if (categoryId <= 0) throw new ArgumentOutOfRangeException(nameof(categoryId));

            _builder.Clear();
            _builder.Append($"categories/{categoryId}/skus");
            _builder.Append($"?order_by={orderBy}");
            _builder.Append($"&order_dir={orderDir}");
            _builder.Append($"&oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Entities.SKUs.SKUs>(t.Result.ToString()));
        }
    }
}
