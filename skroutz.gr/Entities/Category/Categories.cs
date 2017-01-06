using skroutz.gr.Entities.Shared;
using System.Collections.Generic;

namespace skroutz.gr.Entities.Category
{
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public int children_count { get; set; }
        public string image_url { get; set; }
        public int parent_id { get; set; }
        public bool fashion { get; set; }
        public string layout_mode { get; set; }
        public string web_uri { get; set; }
        public string code { get; set; }
        public string path { get; set; }
        public bool show_specifications { get; set; }
        public string manufacturer_title { get; set; }
    }

    public class Categories
    {
        public List<Category> categories { get; set; }
        public Meta meta { get; set; }
    }

}
