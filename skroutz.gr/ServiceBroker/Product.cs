// ***********************************************************************
// Assembly         : skroutz.gr
// Author           : kakal
// Created          : 01-15-2017
//
// Last Modified By : kakal
// Last Modified On : 01-21-2017
// ***********************************************************************
// <copyright file="Product.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using skroutz.gr.Entities;
using skroutz.gr.ServiceBroker;
using skroutz.gr.Shared;
using System;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace skroutz.gr.ServiceBroker
{
    /// <summary>
    /// Provides methods for accesing Product's data.
    /// </summary>
    /// <seealso cref="skroutz.gr.ServiceBroker.Request" />
    public class Product : Request
    {
        /// <summary>
        /// The builder
        /// </summary>
        private readonly StringBuilder _builder;
        /// <summary>
        /// The access token
        /// </summary>
        private readonly SkroutzRequest _skroutzRequest;

        /// <summary>
        /// Initializes a new instance of the <see cref="Category" /> class
        /// </summary>
        /// <param name="skroutzRequest">The access token provided by the OAuth2.0 protocol</param>
        public Product(SkroutzRequest skroutzRequest)
        {
            _skroutzRequest = skroutzRequest;
            _builder = new StringBuilder();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Category" /> class
        /// </summary>
        /// <param name="skroutzRequest">The access token provided by the OAuth2.0 protocol</param>
        /// <param name="stringBuilder">The string builder to write to.</param>
        public Product(SkroutzRequest skroutzRequest, StringBuilder stringBuilder)
        {
            _skroutzRequest = skroutzRequest;
            _builder = stringBuilder;
        }

        /// <summary>
        /// Retrieve a single product
        /// </summary>
        /// <param name="productId">Unique Identifier of the product</param>
        /// <param name="sparseFields">The sparse fields.</param>
        /// <returns>Task&lt;RootProduct&gt;.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when <paramref name="productId" /> is less than or equal to 0.</exception>
        /// <see href="https://developer.skroutz.gr/api/v3/product/#retrieve-a-single-product" />
        public Task<RootProduct> RetrieveSingleProduct(int productId, params Expression<Func<Entities.Base.Product, object>>[] sparseFields)
        {
            if (productId <= 0) throw new ArgumentOutOfRangeException(nameof(productId));

            _builder.Clear();
            _builder.Append($"products/{productId}?");

            if(sparseFields.Length > 0)
                _builder.Append($"fields[root]={NameReader.GetMemberNames(sparseFields)}");

            _skroutzRequest.Path = _builder.ToString();

            return GetWebResultAsync(_skroutzRequest).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<RootProduct>(t.Result.ToString()));
        }

        /// <summary>
        /// Search for products
        /// </summary>
        /// <param name="shopId">Unique identifier of the shop</param>
        /// <param name="shopUid">Search with the product identifier as assigned by the shop</param>
        /// <param name="sparseFields">The sparse fields.</param>
        /// <returns>Task&lt;Products&gt;.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when <paramref name="shopId" /> or <paramref name="shopUid" /> is less than or equal to 0.</exception>
        /// <see href="https://developer.skroutz.gr/api/v3/product/#search-for-products" />
        public Task<Products> SearchForProducts(int shopId, string shopUid, params Expression<Func<Entities.Base.Product, object>>[] sparseFields)
        {
            if (shopId <= 0) throw new ArgumentOutOfRangeException(nameof(shopId));
            if (string.IsNullOrEmpty(shopUid)) throw new ArgumentNullException(nameof(shopUid));

            _builder.Clear();
            _builder.Append($"shops/{shopId}/products/search?");
            _builder.Append($"shop_uid={shopUid}");

            if (sparseFields.Length > 0)
                _builder.Append($"&fields[root]={NameReader.GetMemberNames(sparseFields)}");

            _skroutzRequest.Path = _builder.ToString();

            return GetWebResultAsync(_skroutzRequest).ContinueWith((t) =>
                    JsonConvert.DeserializeObject<Products>(t.Result.ToString()));
        }
    }
}
