using Newtonsoft.Json;
using skroutz.gr.Entities;
using skroutz.gr.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
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

        /// <summary>
        /// Initializes a new instance of the SKU class
        /// </summary>
        /// <param name="accessToken">The access token provided by the OAuth2.0 protocol</param>
        public SKU(string accessToken)
        {
            _accessToken = accessToken;
            _builder = new StringBuilder();
        }

        /// <summary>
        /// Initializes a new instance of the SKU class
        /// </summary>
        /// <param name="accessToken">The access token provided by the OAuth2.0 protocol</param>
        /// <param name="stringBuilder">The string builder to write to.</param>
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
        /// <param name="orderDir">Order by ascending or descending</param>
        /// <param name="searchKeyword">The keyword to search by</param>
        /// <param name="manufacturerIds">The ids of the manufacturers of the SKUs</param>
        /// <param name="filterIds">The ids of the filters to be applied on the SKUs</param>
        /// <see href="https://developer.skroutz.gr/api/v3/sku/#list-skus-of-specific-category"/>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when categoryId is less than or equal to 0</exception>
        /// <remarks>The default order_by value may differ across categories but in most cases it's pricevat.</remarks>
        public Task<SKUs> ListSKUsOfSpecificCategory(int categoryId, OrderByPrcPopRating orderBy = OrderByPrcPopRating.pricevat, OrderDir orderDir = OrderDir.asc, string searchKeyword = null, IList<int> manufacturerIds = null, IList<int> filterIds = null)
        {
            if (categoryId <= 0) throw new ArgumentOutOfRangeException(nameof(categoryId));

            _builder.Clear();
            _builder.Append($"categories/{categoryId}/skus");
            _builder.Append($"?order_by={orderBy}");
            _builder.Append($"&order_dir={orderDir}");

            if (!string.IsNullOrEmpty(searchKeyword))
                _builder.Append($"&q={searchKeyword}");

            if (manufacturerIds != null)
                _builder.Append($"&manufacturer_ids[]={string.Join("&manufacturer_ids[]=", manufacturerIds.Select(s => s.ToString()))}");

            if (filterIds != null)
                _builder.Append($"&filter_ids[]={string.Join("&filter_ids[]=", filterIds.Select(s => s.ToString()))}");

            _builder.Append($"&oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<SKUs>(t.Result.ToString()));
        }

        /// <summary>
        /// Retrieve a single SKU
        /// </summary>
        /// <param name="SKUId">Unique identifier of the SKU</param>
        /// <see href="https://developer.skroutz.gr/api/v3/sku/#retrieve-a-single-sku"/>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when SKUId is less than or equal to 0</exception>
        /// <returns></returns>
        public Task<RootSKU> RetrieveSingleSKU(int SKUId)
        {
            if (SKUId <= 0) throw new ArgumentOutOfRangeException(nameof(SKUId));

            _builder.Clear();
            _builder.Append($"skus/{SKUId}");

            _builder.Append($"&oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<RootSKU>(t.Result.ToString()));
        }

        /// <summary>
        /// Retrieve similar SKUs
        /// </summary>
        /// <param name="SKUId">Unique identifier of the SKU</param>
        /// <see href="https://developer.skroutz.gr/api/v3/sku/#retrieve-similar-skus"/>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when SKUId is less than or equal to 0</exception>
        /// <returns></returns>
        public Task<SKUs> RetrieveSimilarSKUs(int SKUId)
        {
            if (SKUId <= 0) throw new ArgumentOutOfRangeException(nameof(SKUId));

            _builder.Clear();
            _builder.Append($"skus/{SKUId}/similar");

            _builder.Append($"&oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<SKUs>(t.Result.ToString()));
        }

        /// <summary>
        /// Retrieve an SKU's products
        /// </summary>
        /// <param name="SKUId">Unique identifier of the SKU</param>
        /// <see href="https://developer.skroutz.gr/api/v3/sku/#retrieve-an-skus-products"/>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when SKUId is less than or equal to 0</exception>
        /// <returns></returns>
        public Task<Products> RetrieveSKUsProducts(int SKUId)
        {
            if (SKUId <= 0) throw new ArgumentOutOfRangeException(nameof(SKUId));

            _builder.Clear();
            _builder.Append($"skus/{SKUId}/products");

            _builder.Append($"&oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Products>(t.Result.ToString()));
        }

        /// <summary>
        /// Retrieve an SKU's reviews
        /// </summary>
        /// <param name="SKUId">Unique identifier of the SKU</param>
        /// <see href="https://developer.skroutz.gr/api/v3/sku/#retrieve-an-skus-reviews"/>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when SKUId is less than or equal to 0</exception>
        /// <returns></returns>
        public Task<Reviews> RetrieveSKUsReviews(int SKUId)
        {
            if (SKUId <= 0) throw new ArgumentOutOfRangeException(nameof(SKUId));

            _builder.Clear();
            _builder.Append($"skus/{SKUId}/reviews");

            _builder.Append($"&oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Reviews>(t.Result.ToString()));
        }
    }
}
