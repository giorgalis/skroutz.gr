using Newtonsoft.Json;
using skroutz.gr.Entities;
using skroutz.gr.Entities.Base;
using skroutz.gr.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        private readonly SkroutzRequest _skroutzRequest;

        /// <summary>
        /// Initializes a new instance of the <see cref="Sku" /> class
        /// </summary>
        /// <param name="skroutzRequest">Instance of the SkroutzRequest class</param>
        public Sku(SkroutzRequest skroutzRequest)
        {
            _skroutzRequest = skroutzRequest;
        }

        /// <summary>
        /// List SKUs of specific category.
        /// </summary>
        /// <param name="categoryId">Unique identifier of the Category</param>
        /// <param name="orderBy">Order by price, popularity or rating</param>
        /// <param name="orderDir">Order by ascending or descending</param>
        /// <param name="searchKeyword">The keyword to search by</param>
        /// <param name="metaFilters">The meta filters.</param>
        /// <param name="manufacturerIds">The ids of the manufacturers of the SKUs</param>
        /// <param name="filterIds">The ids of the filters to be applied on the SKUs</param>
        /// <param name="sparseFields">Sparse fields are a way for clients to request specific json fields from the server response.</param>
        /// <returns>Task&lt;SKUs&gt;.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="categoryId" /> is less than or equal to 0.</exception>
        /// <see href="https://developer.skroutz.gr/api/v3/sku/#list-skus-of-specific-category"></see>
        /// <remarks>The default <c>order_by value</c> may differ across categories but in most cases it's <c>pricevat</c>.</remarks>
        public Task<SKUs> ListSKUsOfSpecificCategory(int categoryId, OrderByPrcPopRating orderBy = OrderByPrcPopRating.pricevat, OrderDir orderDir = OrderDir.asc, string searchKeyword = null, MetaFilters? metaFilters = null, IList<int> manufacturerIds = null, IList<int> filterIds = null, params Expression<Func<SKU, object>>[] sparseFields)
        {
            if (categoryId <= 0) throw new ArgumentOutOfRangeException(nameof(categoryId));
            //TODO: perform check
            //if (metaFilters.HasValue && metaFilters == MetaFilters.AppliedFilters)
            //{
            //    if(manufacturerIds == null && filterIds == null) throw new ArgumentOutOfRangeException(nameof(metaFilters));
            //}

            _skroutzRequest.SBuilder.Clear();
            _skroutzRequest.SBuilder.Append($"categories/{categoryId}/skus?");
            _skroutzRequest.SBuilder.Append($"order_by={orderBy}");
            _skroutzRequest.SBuilder.Append($"&order_dir={orderDir}");

            if (!string.IsNullOrEmpty(searchKeyword))
                _skroutzRequest.SBuilder.Append($"&q={searchKeyword}");

            if (manufacturerIds != null)
                _skroutzRequest.SBuilder.Append($"&manufacturer_ids[]={string.Join("&manufacturer_ids[]=", manufacturerIds.Select(s => s.ToString()))}");

            if (filterIds != null)
                _skroutzRequest.SBuilder.Append($"&filter_ids[]={string.Join("&filter_ids[]=", filterIds.Select(s => s.ToString()))}");

            if (sparseFields.Length > 0)
                _skroutzRequest.SBuilder.Append($"&fields[root]={NameReader.GetMemberNames(sparseFields)}");

            return GetWebResultAsync(_skroutzRequest).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<SKUs>(t.Result.ToString()));
        }

        /// <summary>
        /// Retrieve a single SKU.
        /// </summary>
        /// <param name="skuId">Unique identifier of the SKU</param>
        /// <param name="sparseFields">Sparse fields are a way for clients to request specific json fields from the server response.</param>
        /// <returns>Task&lt;RootSKU&gt;.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="skuId" /> is less than or equal to 0.</exception>
        /// <see href="https://developer.skroutz.gr/api/v3/sku/#retrieve-a-single-sku" />
        public Task<RootSKU> RetrieveSingleSKU(int skuId, params Expression<Func<SKU, object>>[] sparseFields)
        {
            if (skuId <= 0) throw new ArgumentOutOfRangeException(nameof(skuId));

            _skroutzRequest.SBuilder.Clear();
            _skroutzRequest.SBuilder.Append($"skus/{skuId}");

            if (sparseFields.Length > 0)
                _skroutzRequest.SBuilder.Append($"&fields[root]={NameReader.GetMemberNames(sparseFields)}");

            return GetWebResultAsync(_skroutzRequest).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<RootSKU>(t.Result.ToString()));
        }

        /// <summary>
        /// Retrieve similar SKUs.
        /// </summary>
        /// <param name="skuId">Unique identifier of the SKU</param>
        /// <param name="sparseFields">Sparse fields are a way for clients to request specific json fields from the server response.</param>
        /// <returns>Task&lt;SKUs&gt;.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="skuId" /> is less than or equal to 0.</exception>
        /// <see href="https://developer.skroutz.gr/api/v3/sku/#retrieve-similar-skus" />
        public Task<SKUs> RetrieveSimilarSKUs(int skuId, params Expression<Func<SKU, object>>[] sparseFields)
        {
            if (skuId <= 0) throw new ArgumentOutOfRangeException(nameof(skuId));

            _skroutzRequest.SBuilder.Clear();
            _skroutzRequest.SBuilder.Append($"skus/{skuId}/similar?");

            if (sparseFields.Length > 0)
                _skroutzRequest.SBuilder.Append($"&fields[root]={NameReader.GetMemberNames(sparseFields)}");

            return GetWebResultAsync(_skroutzRequest).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<SKUs>(t.Result.ToString()));
        }

        /// <summary>
        /// Retrieve an SKU's products.
        /// </summary>
        /// <param name="skuId">Unique identifier of the SKU</param>
        /// <param name="sparseFields">Sparse fields are a way for clients to request specific json fields from the server response.</param>
        /// <returns>Task&lt;Products&gt;.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="skuId" /> is less than or equal to 0..</exception>
        /// <see href="https://developer.skroutz.gr/api/v3/sku/#retrieve-an-skus-products" />
        public Task<Products> RetrieveSKUsProducts(int skuId, params Expression<Func<Entities.RootProduct, object>>[] sparseFields)
        {
            if (skuId <= 0) throw new ArgumentOutOfRangeException(nameof(skuId));

            _skroutzRequest.SBuilder.Clear();
            _skroutzRequest.SBuilder.Append($"skus/{skuId}/products?");

            if (sparseFields.Length > 0)
                _skroutzRequest.SBuilder.Append($"fields[root]={NameReader.GetMemberNames(sparseFields)}");

            return GetWebResultAsync(_skroutzRequest).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Products>(t.Result.ToString()));
        }

        /// <summary>
        /// Retrieve an SKU's reviews.
        /// </summary>
        /// <param name="skuId">Unique identifier of the SKU</param>
        /// <param name="sparseFields">Sparse fields are a way for clients to request specific json fields from the server response.</param>
        /// <returns>Task&lt;Reviews&gt;.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="skuId" /> is less than or equal to 0.</exception>
        /// <see href="https://developer.skroutz.gr/api/v3/sku/#retrieve-an-skus-reviews" />
        public Task<Reviews> RetrieveSKUsReviews(int skuId, params Expression<Func<SKUReview, object>>[] sparseFields)
        {
            if (skuId <= 0) throw new ArgumentOutOfRangeException(nameof(skuId));

            _skroutzRequest.SBuilder.Clear();
            _skroutzRequest.SBuilder.Append($"skus/{skuId}/reviews?");

            if (sparseFields.Length > 0)
                _skroutzRequest.SBuilder.Append($"fields[root]={NameReader.GetMemberNames(sparseFields)}");

            return GetWebResultAsync(_skroutzRequest).ContinueWith((t) =>
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
        /// <remarks>Requires user token with the <c>'publish_sku_review_actions'</c>/ permission.</remarks>
        /// <returns>Task&lt;RootSKUReviewVote&gt;.</returns>
        public Task<RootSKUReviewVote> VoteSKUsReview(int skuId, int reviewId, bool helpful)
        {
            if (skuId <= 0) throw new ArgumentOutOfRangeException(nameof(skuId));
            if (reviewId <= 0) throw new ArgumentOutOfRangeException(nameof(reviewId));

            _skroutzRequest.SBuilder.Clear();
            _skroutzRequest.SBuilder.Append($"skus/{skuId}/reviews/{reviewId}votes?vote[helpful]={helpful.ToString().ToLower()}");

            _skroutzRequest.Method = HttpMethod.POST;

            return GetWebResultAsync(_skroutzRequest).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<RootSKUReviewVote>(t.Result.ToString()));
        }

        /// <summary>
        /// Flag an SKU's review.
        /// </summary>
        /// <param name="skuId">Unique identifier of the SKU</param>
        /// <param name="reviewId">Unique identifier of the Review</param>
        /// <param name="flagReason"></param>
        /// <see href="https://developer.skroutz.gr/api/v3/sku/#flag-a-skus-review"/>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="skuId"/> is less than or equal to 0.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="reviewId"/> is less than or equal to 0.</exception>
        /// <remarks>Requires user token with the <c>'publish_sku_review_actions'</c> permission.</remarks>
        /// <remarks>To retrieve all available flags, see <see cref="Flag"/>.</remarks>
        /// <remarks>Returns empty body, unless an error occurs.</remarks>
        /// <returns>Task&lt;SKUReviewFlag&gt;.</returns>
        public Task<SKUReviewFlag> FlagSKUsReview(int skuId, int reviewId, string flagReason)
        {
            if (skuId <= 0) throw new ArgumentOutOfRangeException(nameof(skuId));
            if (reviewId <= 0) throw new ArgumentOutOfRangeException(nameof(reviewId));

            _skroutzRequest.SBuilder.Clear();
            _skroutzRequest.SBuilder.Append($"skus/{skuId}/reviews/{reviewId}flags?flag[reason]={flagReason}");

            _skroutzRequest.Method = HttpMethod.POST;

            return GetWebResultAsync(_skroutzRequest).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<SKUReviewFlag>(t.Result.ToString()));
        }

        /// <summary>
        /// Retrieve SKUs Specifications.
        /// </summary>
        /// <param name="skuId">Unique identifier of the SKU</param>
        /// <param name="sparseFields">Sparse fields are a way for clients to request specific json fields from the server response.</param>
        /// <returns>Task&lt;Specifications&gt;.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="skuId" /> is less than or equal to 0.</exception>
        /// <see href="https://developer.skroutz.gr/api/v3/sku/#retrieve-an-skus-specifications" />
        /// <remarks>Pagination is not available for this endpoint.</remarks>
        public Task<Specifications> RetrieveSKUsSpecifications(int skuId, params Expression<Func<Specification, object>>[] sparseFields)
        {
            if (skuId <= 0) throw new ArgumentOutOfRangeException(nameof(skuId));
            
            _skroutzRequest.SBuilder.Clear();
            _skroutzRequest.SBuilder.Append($"skus/{skuId}/specifications?");

            if (sparseFields.Length > 0)
                _skroutzRequest.SBuilder.Append($"fields[root]={NameReader.GetMemberNames(sparseFields)}");

            return GetWebResultAsync(_skroutzRequest).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Specifications>(t.Result.ToString()));
        }

        /// <summary>
        /// Retrieve SKUs Price History.
        /// </summary>
        /// <param name="skuId">Unique identifier of the SKU</param>
        /// <param name="sparseFields">Sparse fields are a way for clients to request specific json fields from the server response.</param>
        /// <returns>Task&lt;PriceHistory&gt;.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="skuId" /> is less than or equal to 0.</exception>
        /// <see href="https://developer.skroutz.gr/api/v3/sku/#retrieve-a-skus-price-history" />
        /// <remarks>Currently this endpoint responds with any available data for the last 6 months</remarks>
        public Task<PriceHistory> RetrieveSKUsPriceHistory(int skuId, params Expression<Func<History, object>>[] sparseFields)
        {
            if (skuId <= 0) throw new ArgumentOutOfRangeException(nameof(skuId));

            _skroutzRequest.SBuilder.Clear();
            _skroutzRequest.SBuilder.Append($"skus/{skuId}/price_history?");

            if (sparseFields.Length > 0)
                _skroutzRequest.SBuilder.Append($"fields[root]={NameReader.GetMemberNames(sparseFields)}");

            return GetWebResultAsync(_skroutzRequest).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<PriceHistory>(t.Result.ToString()));
        }

        /// <summary>
        /// Retrieve SKUs Favorite. If the SKU has been favorited by the currently associated user, you can fetch it.
        /// </summary>
        /// <param name="skuId">Unique identifier of the SKU</param>
        /// <see href="https://developer.skroutz.gr/api/v3/sku/#retrieve-an-skus-favorite"/>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="skuId"/> is less than or equal to 0.</exception>
        /// <remarks>Requires user token with the 'favorites' permission.</remarks>
        /// <returns>Task&lt;PriceHistory&gt;.</returns>
        public Task<PriceHistory> RetrieveSKUsFavorite(int skuId)
        {
            throw new NotImplementedException();
            //if (sKUId <= 0) throw new ArgumentOutOfRangeException(nameof(sKUId));

            //_skroutzRequest.StringBuilder.Clear();
            //_skroutzRequest.StringBuilder.Append($"skus/{sKUId}/favorite?");
            //_skroutzRequest.StringBuilder.Append($"oauth_token={_accessToken}");

            //return _skroutzRequest.GetWebResultAsync(_skroutzRequest.StringBuilder.ToString()).ContinueWith((t) =>
            //        JsonConvert.DeserializeObject<PriceHistory>(t.Result.ToString()));
        }

    }
}
