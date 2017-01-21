using Newtonsoft.Json;
using skroutz.gr.Entities.Base;
using skroutz.gr.Entities;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace skroutz.gr.ServiceBroker
{
    /// <summary>
    /// Provides methods for accesing Shop's data including shop locations, shop reviews and other.
    /// </summary>
    public class Shop : Request
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
        /// Initializes a new instance of the <see cref="Shop" /> class
        /// </summary>
        /// <param name="accessToken">The access token provided by the OAuth2.0 protocol</param>
        public Shop(string accessToken)
        {
            _accessToken = accessToken;
            _builder = new StringBuilder();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Shop" /> class
        /// </summary>
        /// <param name="accessToken">The access token provided by the OAuth2.0 protocol</param>
        /// <param name="stringBuilder">The string builder to write to.</param>
        public Shop(string accessToken, StringBuilder stringBuilder)
        {
            _accessToken = accessToken;
            _builder = stringBuilder;
        }

        /// <summary>
        /// Retrieve single shop
        /// </summary>
        /// <param name="shopId">The shop identifier.</param>
        /// <param name="sparseFields">The sparse fields.</param>
        /// <returns>Task&lt;RootShop&gt;.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="shopId" /> is less than or equal to 0.</exception>
        /// <see href="https://developer.skroutz.gr/api/v3/shop/#retrieve-a-single-shop" />
        public Task<RootShop> RetrieveSingleShop(int shopId, params Expression<Func<RootShop, object>>[] sparseFields)
        {
            if (shopId <= 0) throw new ArgumentOutOfRangeException(nameof(shopId));

            _builder.Clear();
            _builder.Append($"shops/{shopId}?");
            _builder.Append($"oauth_token={_accessToken}");

            if (sparseFields != null)
                _builder.Append($"&fields[root]={NameReader.GetMemberNames(sparseFields)}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<RootShop>(t.Result.ToString()));
        }

        /// <summary>
        /// Retrieves the shop review.
        /// </summary>
        /// <param name="shopId">The shop identifier.</param>
        /// <param name="sparseFields">The sparse fields.</param>
        /// <returns>Task&lt;ShopReviews&gt;.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="shopId" /> is less than or equal to 0.</exception>
        /// <see href="https://developer.skroutz.gr/api/v3/shop/#retrieve-a-shops-reviews" />
        public Task<ShopReviews> RetrieveShopReview(int shopId, params Expression<Func<ShopReview, object>>[] sparseFields)
        {
            if (shopId <= 0) throw new ArgumentOutOfRangeException(nameof(shopId));

            _builder.Clear();
            _builder.Append($"shops/{shopId}/reviews?");
            _builder.Append($"oauth_token={_accessToken}");

            if (sparseFields != null)
                _builder.Append($"&fields[root]={NameReader.GetMemberNames(sparseFields)}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<ShopReviews>(t.Result.ToString()));
        }

        /// <summary>
        /// Lists the shop locations.
        /// </summary>
        /// <param name="shopId">The shop identifier.</param>
        /// <param name="sparseFields">The sparse fields.</param>
        /// <returns>Task&lt;ShopLocations&gt;.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="shopId" /> is less than or equal to 0.</exception>
        /// <see href="https://developer.skroutz.gr/api/v3/shop/#list-shop-locations" />
        public Task<ShopLocations> ListShopLocations(int shopId, params Expression<Func<Location, object>>[] sparseFields)
        {
            if (shopId <= 0) throw new ArgumentOutOfRangeException(nameof(shopId));

            _builder.Clear();
            _builder.Append($"shops/{shopId}/locations?");
            _builder.Append($"oauth_token={_accessToken}");

            if (sparseFields != null)
                _builder.Append($"&fields[root]={NameReader.GetMemberNames(sparseFields)}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<ShopLocations>(t.Result.ToString()));
        }


        /// <summary>
        /// Retrieves the single shop location.
        /// </summary>
        /// <param name="shopId">The shop identifier.</param>
        /// <param name="locationId">The location identifier.</param>
        /// <param name="sparseFields">The sparse fields.</param>
        /// <returns>Task&lt;Location&gt;.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="shopId" /> or <paramref name="locationId" /> is less than or equal to 0.</exception>
        /// <see href="https://developer.skroutz.gr/api/v3/shop/#retrieve-a-single-shop-location" />
        public Task<Location> RetrieveSingleShopLocation(int shopId, int locationId, params Expression<Func<Location, object>>[] sparseFields)
        {
            if (shopId <= 0) throw new ArgumentOutOfRangeException(nameof(shopId));
            if (locationId <= 0) throw new ArgumentOutOfRangeException(nameof(locationId));

            _builder.Clear();
            _builder.Append($"shops/{shopId}/locations?");
            _builder.Append($"oauth_token={_accessToken}");

            if (sparseFields != null)
                _builder.Append($"&fields[root]={NameReader.GetMemberNames(sparseFields)}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Location>(t.Result.ToString()));
        }

        /// <summary>
        /// Searches for shops.
        /// </summary>
        /// <param name="searchString">The search string.</param>
        /// <param name="sparseFields">The sparse fields.</param>
        /// <returns>Task&lt;Shops&gt;.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="searchString" /> is null or empty</exception>
        /// <see href="https://developer.skroutz.gr/api/v3/shop/#search-for-shops" />
        public Task<Shops> SearchForShops(string searchString, params Expression<Func<Entities.RootShop, object>>[] sparseFields)
        {
            if (string.IsNullOrEmpty(searchString)) throw new ArgumentNullException(nameof(searchString));

            _builder.Clear();
            _builder.Append($"shops/search?q={searchString}");
            _builder.Append($"oauth_token={_accessToken}");

            if (sparseFields != null)
                _builder.Append($"&fields[root]={NameReader.GetMemberNames(sparseFields)}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Shops>(t.Result.ToString()));
        }
    }
}

