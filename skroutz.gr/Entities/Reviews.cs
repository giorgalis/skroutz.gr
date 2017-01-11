using skroutz.gr.Shared;
using System.Collections.Generic;

namespace skroutz.gr.Entities
{
    public class Review
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string review { get; set; }
        public int rating { get; set; }
        public string created_at { get; set; }
        public bool demoted { get; set; }
        public int votes_count { get; set; }
        public int helpful_votes_count { get; set; }
        public bool voted { get; set; }
        public bool flagged { get; set; }
        public bool helpful { get; set; }
    }

    public class Reviews
    {
        public List<Review> reviews { get; set; }
        public Meta meta { get; set; }
    }
}
