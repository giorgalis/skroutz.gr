using skroutz.gr.Entities.Shared;
using System.Collections.Generic;

namespace skroutz.gr.Entities.Shop
{
    public class Review
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string review { get; set; }
        public double rating { get; set; }
        public object shop_reply { get; set; }
        public string created_at { get; set; }
        public bool negative { get; set; }
        public List<string> reasons { get; set; }
    }

    public class Reviews
    {
        public List<Review> reviews { get; set; }
        public Meta meta { get; set; }
    }

}
