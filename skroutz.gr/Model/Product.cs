using Newtonsoft.Json;
using skroutz.gr.Shared;
using System.Collections.Generic;

namespace skroutz.gr.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class RootProduct
    {
        /// <summary>
        /// 
        /// </summary>
        public Base.Product product { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Products
    {
        /// <summary>
        /// 
        /// </summary>
        public List<Base.Product> products { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Meta meta { get; set; }
    }
}

namespace Base
{
    public class Product
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("sku_id")]
        public int SkuId { get; set; }

        [JsonProperty("shop_id")]
        public int ShopId { get; set; }

        [JsonProperty("category_id")]
        public int CategoryId { get; set; }

        [JsonProperty("availability")]
        public string Availability { get; set; }

        [JsonProperty("click_url")]
        public string ClickUrl { get; set; }

        [JsonProperty("shop_uid")]
        public string ShopUid { get; set; }

        [JsonProperty("expenses")]
        public object Expenses { get; set; }

        [JsonProperty("web_uri")]
        public string WebUri { get; set; }

        [JsonProperty("sizes")]
        public List<object> Sizes { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("immediate_pickup")]
        public bool ImmediatePickup { get; set; }
    }
}
