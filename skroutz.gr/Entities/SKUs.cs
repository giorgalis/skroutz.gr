using Newtonsoft.Json;
using skroutz.gr.Shared;
using System.Collections.Generic;

namespace skroutz.gr.Entities
{
    /// <summary>
    /// RootSKU
    /// </summary>
    public class RootSKU
    {
        /// <summary>
        /// Sku
        /// </summary>
        public Base.Sku sku { get; set; }
    }

    /// <summary>
    /// SKUs
    /// </summary>
    public class SKUs
    {
        /// <summary>
        /// SKUs
        /// </summary>
        public List<Base.Sku> skus { get; set; }

        /// <summary>
        /// Meta
        /// </summary>
        public Meta meta { get; set; }
    }
}

namespace skroutz.gr.Entities.Base
{
    /// <summary>
    /// Sku
    /// </summary>
    public class Sku
    {
        /// <summary>
        /// Id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Ean
        /// </summary>
        [JsonProperty("ean")]
        public string Ean { get; set; }

        /// <summary>
        /// Pn
        /// </summary>
        [JsonProperty("pn")]
        public string Pn { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// DisplayName
        /// </summary>
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        /// <summary>
        /// CategoryId
        /// </summary>
        [JsonProperty("category_id")]
        public int CategoryId { get; set; }

        /// <summary>
        /// FirstProductShopInfo
        /// </summary>
        [JsonProperty("first_product_shop_info")]
        public string FirstProductShopInfo { get; set; }

        /// <summary>
        /// ClickUrl
        /// </summary>
        [JsonProperty("click_url")]
        public object ClickUrl { get; set; }

        /// <summary>
        /// PriceMax
        /// </summary>
        [JsonProperty("price_max")]
        public double PriceMax { get; set; }

        /// <summary>
        /// PriceMin
        /// </summary>
        [JsonProperty("price_min")]
        public double PriceMin { get; set; }

        /// <summary>
        /// ReviewScore
        /// </summary>
        [JsonProperty("reviewscore")]
        public double ReviewScore { get; set; }

        /// <summary>
        /// ShopCount
        /// </summary>
        [JsonProperty("shop_count")]
        public int ShopCount { get; set; }

        /// <summary>
        /// PlainSpecSummary
        /// </summary>
        [JsonProperty("plain_spec_summary")]
        public string PlainSpecSummary { get; set; }

        /// <summary>
        /// ManufacturerId
        /// </summary>
        [JsonProperty("manufacturer_id")]
        public int ManufacturerId { get; set; }

        /// <summary>
        /// Future
        /// </summary>
        [JsonProperty("future")]
        public bool Future { get; set; }

        /// <summary>
        /// ReviewsCount
        /// </summary>
        [JsonProperty("reviews_count")]
        public int ReviewsCount { get; set; }

        /// <summary>
        /// Virtual
        /// </summary>
        [JsonProperty("virtual")]
        public bool Virtual { get; set; }

        /// <summary>
        /// Images
        /// </summary>
        [JsonProperty("images")]
        public Images Images { get; set; }

        /// <summary>
        /// WebUri
        /// </summary>
        [JsonProperty("web_uri")]
        public string WebUri { get; set; }

        /// <summary>
        /// Favorited
        /// </summary>
        [JsonProperty("favorited")]
        public bool Favorited { get; set; }
    }
}
