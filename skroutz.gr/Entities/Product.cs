using System.Collections.Generic;

namespace skroutz.gr.Entities
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public int sku_id { get; set; }
        public int shop_id { get; set; }
        public int category_id { get; set; }
        public string availability { get; set; }
        public string click_url { get; set; }
        public string shop_uid { get; set; }
        public object expenses { get; set; }
        public string web_uri { get; set; }
        public List<object> sizes { get; set; }
        public double price { get; set; }
        public bool immediate_pickup { get; set; }
    }
}
