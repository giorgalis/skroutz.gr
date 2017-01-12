namespace skroutz.gr.Entities
{
    public class RootSKUReviewVote
    {
        public Base.SkuReviewVote sku_review_vote { get; set; }
    }
}

namespace skroutz.gr.Entities.Base
{
    public class SkuReviewVote
    {
        public int id { get; set; }
        public int sku_review_id { get; set; }
        public int user_id { get; set; }
        public bool helpful { get; set; }
        public string created_at { get; set; }
    }
}
