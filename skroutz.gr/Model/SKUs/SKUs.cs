using skroutz.gr.Model.Shared;
using System.Collections.Generic;

namespace skroutz.gr.Model.SKUs
{
    /// <summary>
    /// Order by price, popularity or rating
    /// </summary>


    public class Sku
    {
        public int id { get; set; }
        public string ean { get; set; }
        public string pn { get; set; }
        public string name { get; set; }
        public string display_name { get; set; }
        public int category_id { get; set; }
        public string first_product_shop_info { get; set; }
        public object click_url { get; set; }
        public double price_max { get; set; }
        public double price_min { get; set; }
        public double reviewscore { get; set; }
        public int shop_count { get; set; }
        public string plain_spec_summary { get; set; }
        public int manufacturer_id { get; set; }
        public bool future { get; set; }
        public int reviews_count { get; set; }
        public bool @virtual { get; set; }
        public Images images { get; set; }
        public string web_uri { get; set; }
        public bool favorited { get; set; }
    }

    public class SKUs
    {
        public List<Sku> skus { get; set; }
        public Meta meta { get; set; }
    }

}
