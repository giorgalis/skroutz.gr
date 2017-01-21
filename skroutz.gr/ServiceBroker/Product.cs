using Newtonsoft.Json;
using skroutz.gr.Entities;
using System;
using System.Text;
using System.Threading.Tasks;

namespace skroutz.gr.ServiceBroker
{
    /// <summary>
    /// Provides methods for accesing Product's data.
    /// </summary>
    public class Product : Request
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
        /// Initializes a new instance of the <see cref="Product" /> class
        /// </summary>
        /// <param name="accessToken">The access token provided by the OAuth2.0 protocol</param>
        public Product(string accessToken)
        {
            _accessToken = accessToken;
            _builder = new StringBuilder();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Product" /> class
        /// </summary>
        /// <param name="accessToken">The access token provided by the OAuth2.0 protocol</param>
        /// <param name="stringBuilder">The string builder to write to.</param>
        public Product(string accessToken, StringBuilder stringBuilder)
        {
            _accessToken = accessToken;
            _builder = stringBuilder;
        }

        /// <summary>
        /// Retrieve a single product
        /// </summary>
        /// <param name="productId">Unique Identifier of the product</param>
        /// <returns>Task&lt;RootProduct&gt;.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when <paramref name="productId"/> is less than or equal to 0.</exception>
        /// <see href="https://developer.skroutz.gr/api/v3/product/#retrieve-a-single-product" />
        public Task<RootProduct> RetrieveSingleProduct(int productId)
        {
            if (productId <= 0) throw new ArgumentOutOfRangeException(nameof(productId));

            _builder.Clear();
            _builder.Append($"products/{productId}?");
            _builder.Append($"oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<RootProduct>(t.Result.ToString()));
        }

        /// <summary>
        /// Search for products
        /// </summary>
        /// <param name="shopId">Unique identifier of the shop</param>
        /// <param name="shopUid">Search with the product identifier as assigned by the shop</param>
        /// <returns>Task&lt;Products&gt;.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="shopId"/> is less than or equal to 0.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="shopUid"/> is less than or equal to 0.</exception>
        /// <see href="https://developer.skroutz.gr/api/v3/product/#search-for-products" />
        public Task<Products> SearchForProducts(int shopId, string shopUid)
        {
            if (shopId <= 0) throw new ArgumentOutOfRangeException(nameof(shopId));
            if (string.IsNullOrEmpty(shopUid)) throw new ArgumentNullException(nameof(shopUid));

            _builder.Clear();
            _builder.Append($"shops/{shopId}/products/search?");
            _builder.Append($"shop_uid={shopUid}");
            _builder.Append($"&oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Products>(t.Result.ToString()));
        }
    }
}
