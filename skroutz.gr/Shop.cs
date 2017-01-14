using Newtonsoft.Json;
using skroutz.gr.Entities.Base;
using skroutz.gr.Entities;
using System;
using System.Text;
using System.Threading.Tasks;


namespace skroutz.gr
{
    /// <summary>
    /// Class Shop.
    /// </summary>
    /// <seealso cref="Request" />
    public class Shop : Request
    {
        private readonly StringBuilder _builder;
        private readonly string _accessToken;

        /// <summary>
        /// Initializes a new instance of the Shop class
        /// </summary>
        /// <param name="accessToken">The access token provided by the OAuth2.0 protocol</param>
        public Shop(string accessToken)
        {
            _accessToken = accessToken;
            _builder = new StringBuilder();
        }

        /// <summary>
        /// Initializes a new instance of the Shop class
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
        /// <returns>Task&lt;RootShop&gt;.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">shopId</exception>
        /// <see href="https://developer.skroutz.gr/api/v3/shop/#retrieve-a-single-shop" />
        public Task<RootShop> RetrieveSingleShop(int shopId)
        {
            if (shopId <= 0) throw new ArgumentOutOfRangeException(nameof(shopId));

            _builder.Clear();
            _builder.Append($"shops/{shopId}?");
            _builder.Append($"oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<RootShop>(t.Result.ToString()));
        }

        /// <summary>
        /// Retrieves the shop review.
        /// </summary>
        /// <param name="shopId">The shop identifier.</param>
        /// <returns>Task&lt;RootShop&gt;.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">shopId</exception>
        public Task<ShopReviews> RetrieveShopReview(int shopId)
        {
            if (shopId <= 0) throw new ArgumentOutOfRangeException(nameof(shopId));

            _builder.Clear();
            _builder.Append($"shops/{shopId}/reviews?");
            _builder.Append($"oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<ShopReviews>(t.Result.ToString()));
        }

        /// <summary>
        /// Lists the shop locations.
        /// </summary>
        /// <param name="shopId">The shop identifier.</param>
        /// <returns>Task&lt;ShopLocations&gt;.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">shopId</exception>
        public Task<ShopLocations> ListShopLocations(int shopId)
        {
            if (shopId <= 0) throw new ArgumentOutOfRangeException(nameof(shopId));

            _builder.Clear();
            _builder.Append($"shops/{shopId}/locations?");
            _builder.Append($"oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<ShopLocations>(t.Result.ToString()));
        }


        /// <summary>
        /// Retrieves the single shop location.
        /// </summary>
        /// <param name="shopId">The shop identifier.</param>
        /// <param name="locationId">The location identifier.</param>
        /// <returns>Task&lt;Location&gt;.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// shopId
        /// or
        /// locationId
        /// </exception>
        public Task<Location> RetrieveSingleShopLocation(int shopId, int locationId)
        {
            if (shopId <= 0) throw new ArgumentOutOfRangeException(nameof(shopId));
            if (locationId <= 0) throw new ArgumentOutOfRangeException(nameof(locationId));

            _builder.Clear();
            _builder.Append($"shops/{shopId}/locations?");
            _builder.Append($"oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Location>(t.Result.ToString()));
        }

        /// <summary>
        /// Searches for shops.
        /// </summary>
        /// <param name="searchString">The search string.</param>
        /// <returns>Task&lt;Shops&gt;.</returns>
        /// <exception cref="System.ArgumentNullException">searchString</exception>
        public Task<Shops> SearchForShops(string searchString)
        {
            if (string.IsNullOrEmpty(searchString)) throw new ArgumentNullException(nameof(searchString));

            _builder.Clear();
            _builder.Append($"shops/search?q={searchString}");
            _builder.Append($"oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Shops>(t.Result.ToString()));
        }
    }
}

