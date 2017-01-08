using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;

namespace skroutz.gr
{
    /// <summary>
    /// Product
    /// </summary>
    public class Product : Request
    {
        private readonly StringBuilder _builder;
        private readonly string _accessToken;

        public Product(string accessToken)
        {
            _accessToken = accessToken;
            _builder = new StringBuilder();
        }

        public Product(string accessToken, StringBuilder stringBuilder)
        {
            _accessToken = accessToken;
            _builder = stringBuilder;
        }

        /// <summary>
        /// Retrieve a single product
        /// </summary>
        /// <param name="productId">Unique Identifier of the product</param>
        /// <see cref="https://developer.skroutz.gr/api/v3/product/#retrieve-a-single-product"/>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when productId is less than or equal to 0</exception>
        public Task<Entities.Product.Product> RetrieveSingleProduct(int productId)
        {
            if (productId <= 0) throw new ArgumentOutOfRangeException(nameof(productId));

            _builder.Clear();
            _builder.Append($"products/{productId}");
            _builder.Append($"?&oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Entities.Product.Product>(t.Result.ToString()));
        }

        /// <summary>
        /// Search for products
        /// </summary>
        /// <param name="shopId">Unique identifier of the shop</param>
        /// <param name="shopUid">Search with the product identifier as assigned by the shop</param>
        /// <see cref="https://developer.skroutz.gr/api/v3/product/#search-for-products"/>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when shopId is less than or equal to 0</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when shopUid is less than or equal to 0</exception>
        public Task<Entities.Product.Product> SearchForProducts(int shopId, int shopUid)
        {
            if (shopId <= 0) throw new ArgumentOutOfRangeException(nameof(shopId));
            if (shopUid <= 0) throw new ArgumentOutOfRangeException(nameof(shopUid));

            _builder.Clear();
            _builder.Append($"shops/{shopId}/products/search?shop_uid={shopUid}");
            _builder.Append($"&oauth_token={_accessToken}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Entities.Product.Product>(t.Result.ToString()));
        }
    }
}
