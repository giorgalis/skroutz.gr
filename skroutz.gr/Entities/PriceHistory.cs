using System.Collections.Generic;

namespace skroutz.gr.Entities
{
    public class Average
    {
        public string date { get; set; }
        public double price { get; set; }
    }

    public class Lowest
    {
        public string date { get; set; }
        public double price { get; set; }
        public string shop_name { get; set; }
    }

    public class History
    {
        public List<Average> average { get; set; }
        public List<Lowest> lowest { get; set; }
    }

    public class PriceHistory
    {
        public History history { get; set; }
    }
}
