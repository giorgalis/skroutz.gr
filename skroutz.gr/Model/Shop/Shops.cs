using System.Collections.Generic;

namespace skroutz.gr.Model.Shop
{
    public class PaymentMethods
    {
        public bool credit_card { get; set; }
        public bool paypal { get; set; }
        public bool bank { get; set; }
        public bool spot_cash { get; set; }
        public string installments { get; set; }
    }

    public class Shipping
    {
        public bool free { get; set; }
        public int free_from { get; set; }
        public string free_from_info { get; set; }
        public string min_price { get; set; }
    }

    public class ExtraInfo
    {
        public string time_on_platform { get; set; }
        public string orders_per_week { get; set; }
    }

    public class Shop
    {
        public int id { get; set; }
        public string name { get; set; }
        public string link { get; set; }
        public string phone { get; set; }
        public string image_url { get; set; }
        public string thumbshot_url { get; set; }
        public int reviews_count { get; set; }
        public int latest_reviews_count { get; set; }
        public double review_score { get; set; }
        public PaymentMethods payment_methods { get; set; }
        public Shipping shipping { get; set; }
        public string web_uri { get; set; }
        public ExtraInfo extra_info { get; set; }
        public List<string> top_positive_reasons { get; set; }
    }

    public class Shops
    {
        public Shop shop { get; set; }
    }
}
