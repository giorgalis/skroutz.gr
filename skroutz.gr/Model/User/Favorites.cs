using skroutz.gr.Model.Shared;
using System.Collections.Generic;

namespace skroutz.gr.Model.User
{
    public class Favorite
    {
        public int id { get; set; }
        public bool have_it { get; set; }
        public int user_id { get; set; }
        public object user_notes { get; set; }
        public int sku_id { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string get_absolute_threshold { get; set; }
    }

    public class Favorites
    {
        public List<Favorite> favorites { get; set; }
        public Meta meta { get; set; }
    }
}
