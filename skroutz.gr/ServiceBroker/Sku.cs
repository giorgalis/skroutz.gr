using Newtonsoft.Json;
using skroutz.gr.Entities;
using skroutz.gr.Entities.Base;
using skroutz.gr.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skroutz.gr.ServiceBroker
{
    /// <summary>
    /// Provides methods for accessing SKU's data, similar SKU's, SKU's of a specific catecory and other.
    /// </summary>
    /// <remarks>A SKU (Stock Keeping Unit) is an aggregation of products.</remarks>
    public class Sku : Request
    {
        private readonly StringBuilder _builder;
        private readonly string _accessToken;

        /// <summary>
        /// Initializes a new instance of the SKU class
        /// </summary>
        /// <param name="accessToken">The access token provided by the OAuth2.0 protocol</param>
        public Sku(string accessToken)
        {
            _accessToken = accessToken;
            _builder = new StringBuilder();
        }

        /// <summary>
        /// Initializes a new instance of the SKU class
        /// </summary>
        /// <param name="accessToken">The access token provided by the OAuth2.0 protocol</param>
        /// <param name="stringBuilder">The string builder to write to.</param>
        public Sku(string accessToken, StringBuilder stringBuilder)
        {
            _accessToken = accessToken;
            _builder = stringBuilder;
        }

        /// <summary>
        /// List SKUs of specific category.
        /// </summary>
        /// <param name="categoryId">Unique identifier of the Category</param>
        /// <param name="orderBy">Order by price, popularity or rating</param>
        /// <param name="orderDir">Order by ascending or descending</param>
        /// <param name="searchKeyword">The keyword to search by</param>
        /// <param name="manufacturerIds">The ids of the manufacturers of the SKUs</param>
        /// <param name="filterIds">The ids of the filters to be applied on the SKUs</param>
        /// <see href="https://developer.skroutz.gr/api/v3/sku/#list-skus-of-specific-category"/>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="categoryId"/> is less than or equal to 0.</exception>
        /// <remarks>The default order_by value may differ across categories but in most cases it's pricevat.</remarks>
        public Task<SKUs> ListSKUsOfSpecificCategory(int categoryId, OrderByPrcPopRating orderBy = OrderByPrcPopRating.pricevat, OrderDir orderDir = OrderDir.asc, string searchKeyword = null, MetaFilters? metaFilters = null, IList<int> manufacturerIds = null, IList<int> filterIds = null)
        {
            if (categoryId <= 0) throw new ArgumentOutOfRangeException(nameof(categoryId));

            //if (metaFilters.HasValue && metaFilters == MetaFilters.AppliedFilters)
            //{
            //    if(manufacturerIds == null && filterIds == null) throw new ArgumentOutOfRangeException(nameof(metaFilters));
            //}

            _builder.Clear();
            _builder.Append($"categories/{categoryId}/skus?");
            _builder.Append($"order_by={orderBy}");
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
        /// Retrieve a single SKU.
        /// </summary>
        /// <param name="skuId">Unique identifier of the SKU</param>
        /// <see href="https://developer.skroutz.gr/api/v3/sku/#retrieve-a-single-sku"/>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="skuId"/> is less than or equal to 0.</exception>
        /// <returns></returns>
        public Task<RootSKU> RetrieveSingleSKU(int skuId)
        {
            if (skuId <= 0) throw new ArgumentOutOfRangeException(nameof(skuId));

            _builder.Clear();
            _builder.Append($"skus/{skuId}?");

            _builder.Append($"oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<RootSKU>(t.Result.ToString()));
        }

        /// <summary>
        /// Retrieve similar SKUs.
        /// </summary>
        /// <param name="skuId">Unique identifier of the SKU</param>
        /// <see href="https://developer.skroutz.gr/api/v3/sku/#retrieve-similar-skus"/>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="skuId"/> is less than or equal to 0.</exception>
        /// <returns></returns>
        public Task<SKUs> RetrieveSimilarSKUs(int skuId)
        {
            if (skuId <= 0) throw new ArgumentOutOfRangeException(nameof(skuId));

            _builder.Clear();
            _builder.Append($"skus/{skuId}/similar?");

            _builder.Append($"oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<SKUs>(t.Result.ToString()));
        }

        /// <summary>
        /// Retrieve an SKU's products.
        /// </summary>
        /// <param name="skuId">Unique identifier of the SKU</param>
        /// <see href="https://developer.skroutz.gr/api/v3/sku/#retrieve-an-skus-products"/>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="skuId"/> is less than or equal to 0..</exception>
        /// <returns></returns>
        public Task<Products> RetrieveSKUsProducts(int skuId)
        {
            if (skuId <= 0) throw new ArgumentOutOfRangeException(nameof(skuId));

            _builder.Clear();
            _builder.Append($"skus/{skuId}/products?");
            _builder.Append($"oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Products>(t.Result.ToString()));
        }

        /// <summary>
        /// Retrieve an SKU's reviews.
        /// </summary>
        /// <param name="skuId">Unique identifier of the SKU</param>
        /// <see href="https://developer.skroutz.gr/api/v3/sku/#retrieve-an-skus-reviews"/>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="skuId"/> is less than or equal to 0.</exception>
        /// <returns></returns>
        public Task<Reviews> RetrieveSKUsReviews(int skuId)
        {
            if (skuId <= 0) throw new ArgumentOutOfRangeException(nameof(skuId));

            _builder.Clear();
            _builder.Append($"skus/{skuId}/reviews?");
            _builder.Append($"oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Reviews>(t.Result.ToString()));
        }

        /// <summary>
        /// Vote an SKU's review.
        /// </summary>
        /// <param name="skuId">Unique identifier of the SKU</param>
        /// <param name="reviewId">Unique identifier of the Review</param>
        /// <param name="helpful">Helpful</param>
        /// <see href="https://developer.skroutz.gr/api/v3/sku/#vote-a-skus-review"/>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="skuId"/> is less than or equal to 0.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="reviewId"/> is less than or equal to 0.</exception>
        /// <remarks>Requires user token with the <code>'publish_sku_review_actions'</code>/ permission.</remarks>
        /// <returns></returns>
        public Task<RootSKUReviewVote> VoteSKUsReview(int skuId, int reviewId, bool helpful)
        {
            //TODO: POST
            if (skuId <= 0) throw new ArgumentOutOfRangeException(nameof(skuId));
            if (reviewId <= 0) throw new ArgumentOutOfRangeException(nameof(reviewId));

            _builder.Clear();
            _builder.Append($"skus/{skuId}/reviews/{reviewId}votes?vote[helpful]={helpful}");
            _builder.Append($"&oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<RootSKUReviewVote>(t.Result.ToString()));
        }

        /// <summary>
        /// Flag a SKU's review.
        /// </summary>
        /// <param name="skuId">Unique identifier of the SKU</param>
        /// <param name="reviewId">Unique identifier of the Review</param>
        /// <param name="flagReason"></param>
        /// <see href="https://developer.skroutz.gr/api/v3/sku/#flag-a-skus-review"/>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="skuId"/> is less than or equal to 0.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="reviewId"/> is less than or equal to 0.</exception>
        /// <remarks>Requires user token with the <code>'publish_sku_review_actions'</code> permission.</remarks>
        /// <remarks>To retrieve all available flags, see <see cref="Flag"/>.</remarks>
        /// <remarks>Returns empty body, unless an error occurs.</remarks>
        /// <returns></returns>
        public Task<SKUReviewFlag> FlagSKUsReview(int skuId, int reviewId, string flagReason)
        {
            //TODO: POST
            //TODO: Read flags
            if (skuId <= 0) throw new ArgumentOutOfRangeException(nameof(skuId));
            if (reviewId <= 0) throw new ArgumentOutOfRangeException(nameof(reviewId));

            _builder.Clear();
            _builder.Append($"skus/{skuId}/reviews/{reviewId}flags?flag[reason]={flagReason}");
            _builder.Append($"&oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<SKUReviewFlag>(t.Result.ToString()));
        }

        /// <summary>
        /// Retrieve SKUs Specifications.
        /// </summary>
        /// <param name="skuId">Unique identifier of the SKU</param>
        /// <see href="https://developer.skroutz.gr/api/v3/sku/#retrieve-an-skus-specifications"/>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="skuId"/> is less than or equal to 0.</exception>
        /// <remarks>Pagination is not available for this endpoint.</remarks>
        /// <returns></returns>
        public Task<Specifications> RetrieveSKUsSpecifications(int skuId)
        {
            if (skuId <= 0) throw new ArgumentOutOfRangeException(nameof(skuId));
            
            _builder.Clear();
            _builder.Append($"skus/{skuId}/specifications?");
            _builder.Append($"oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Specifications>(t.Result.ToString()));
        }

        /// <summary>
        /// Retrieve SKUs Price History.
        /// </summary>
        /// <param name="skuId">Unique identifier of the SKU</param>
        /// <see href="https://developer.skroutz.gr/api/v3/sku/#retrieve-a-skus-price-history"/>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="skuId"/> is less than or equal to 0.</exception>
        /// <remarks>Currently this endpoint responds with any available data for the last 6 months</remarks>
        /// <returns></returns>
        public Task<PriceHistory> RetrieveSKUsPriceHistory(int skuId)
        {
            if (skuId <= 0) throw new ArgumentOutOfRangeException(nameof(skuId));

            _builder.Clear();
            _builder.Append($"skus/{skuId}/price_history?");
            _builder.Append($"oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<PriceHistory>(t.Result.ToString()));
        }

        /// <summary>
        /// Retrieve SKUs Favorite. If the SKU has been favorited by the currently associated user, you can fetch it.
        /// </summary>
        /// <param name="skuId">Unique identifier of the SKU</param>
        /// <see href="https://developer.skroutz.gr/api/v3/sku/#retrieve-an-skus-favorite"/>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="skuId"/> is less than or equal to 0.</exception>
        /// <remarks>Requires user token with the 'favorites' permission.</remarks>
        /// <returns></returns>
        public Task<PriceHistory> RetrieveSKUsFavorite(int skuId)
        {
            throw new NotImplementedException();
            //if (sKUId <= 0) throw new ArgumentOutOfRangeException(nameof(sKUId));

            //_builder.Clear();
            //_builder.Append($"skus/{sKUId}/favorite?");
            //_builder.Append($"oauth_token={_accessToken}");

            //return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
            //        JsonConvert.DeserializeObject<PriceHistory>(t.Result.ToString()));
        }

    }
}
