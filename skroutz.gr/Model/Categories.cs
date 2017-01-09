using skroutz.gr.Model.Shared;
using System.Collections.Generic;

namespace skroutz.gr.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class RootCategory
    {
        /// <summary>
        /// 
        /// </summary>
        public Base.Category category { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Categories
    {
        /// <summary>
        /// 
        /// </summary>
        public List<Base.Category> categories { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Meta meta { get; set; }
    }
}

namespace Base {
    /// <summary>
    /// 
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Category ID
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Category Name
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int children_count { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string image_url { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int parent_id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool fashion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string layout_mode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string web_uri { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string path { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool show_specifications { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string manufacturer_title { get; set; }
    }
}
