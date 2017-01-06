﻿using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace skroutz.gr
{
    public class Product : Request
    {
        private readonly StringBuilder _builder;

        public Product(StringBuilder builder)
        {
            _builder = builder;
        }

        /// <summary>
        /// Retrieve a single product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns>Product</returns>
        public Task<Entities.Product> RetrieveSingleProduct(int productId)
        {
            _builder.Clear();
            _builder.Append($"products/{productId}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Entities.Product>(t.Result.ToString()));
        }

        /// <summary>
        /// Search for products
        /// </summary>
        /// <param name="shopId">Unique identifier of the shop</param>
        /// <param name="shopUid">Search with the product identifier as assigned by the shop</param>
        /// <returns>Product</returns>
        public Task<Entities.Product> SearchForProducts(int shopId, int shopUid)
        {
            _builder.Clear();
            _builder.Append($"shops/{shopId}/products/search?shop_uid={shopUid}");

            return GetWebResultAsync(_builder.ToString()).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Entities.Product>(t.Result.ToString()));
        }
    }
}
