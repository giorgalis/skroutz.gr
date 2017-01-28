using Newtonsoft.Json;
using skroutz.gr.Shared;
using System.Collections.Generic;

namespace skroutz.gr.Entities
{
    /// <summary>
    /// Class RootProduct.
    /// </summary>
    /// <seealso cref="Base.Product"/>
    public class RootProduct
    {
        /// <summary>
        /// Product
        /// </summary>
        [JsonProperty("product")]
        public Base.Product Product { get; set; }
    }

    /// <summary>
    /// Class Products.
    /// </summary>
    /// <seealso cref="Base.Product"/>
    /// <seealso cref="Shared.Meta"/>
    public class Products
    {
        /// <summary>
        /// Products
        /// </summary>
        public List<Base.Product> products { get; set; }

        /// <summary>
        /// Meta
        /// </summary>
        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }
}


namespace skroutz.gr.Entities.Base
{
    /// <summary>
    /// Product
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Product Id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Product Name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Sku Id
        /// </summary>
        [JsonProperty("sku_id")]
        public int SkuId { get; set; }

        /// <summary>
        /// Shop Id
        /// </summary>
        [JsonProperty("shop_id")]
        public int ShopId { get; set; }

        /// <summary>
        /// Category Id
        /// </summary>
        [JsonProperty("category_id")]
        public int CategoryId { get; set; }

        /// <summary>
        /// Availability
        /// </summary>
        [JsonProperty("availability")]
        public string Availability { get; set; }

        /// <summary>
        /// Click Url
        /// </summary>
        [JsonProperty("click_url")]
        public string ClickUrl { get; set; }

        /// <summary>
        /// Shop Uid
        /// </summary>
        [JsonProperty("shop_uid")]
        public string ShopUid { get; set; }

        /// <summary>
        /// Expenses
        /// </summary>
        [JsonProperty("expenses")]
        public object Expenses { get; set; }

        /// <summary>
        /// Web Url
        /// </summary>
        [JsonProperty("web_uri")]
        public string WebUri { get; set; }

        /// <summary>
        /// Sizes
        /// </summary>
        [JsonProperty("sizes")]
        public List<object> Sizes { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        [JsonProperty("price")]
        public double Price { get; set; }

        /// <summary>
        /// Immediate Pickup
        /// </summary>
        [JsonProperty("immediate_pickup")]
        public bool ImmediatePickup { get; set; }
    }
}
