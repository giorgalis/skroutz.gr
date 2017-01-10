using Newtonsoft.Json;
using skroutz.gr.Shared;
using System.Collections.Generic;

namespace skroutz.gr.Models
{
    /// <summary>
    /// Root Category
    /// </summary>
    public class RootCategory
    {
        /// <summary>
        /// Category
        /// </summary>
        public Base.Category category { get; set; }
    }

    /// <summary>
    /// Categories
    /// </summary>
    public class Categories
    {
        /// <summary>
        /// Categories
        /// </summary>
        public List<Base.Category> categories { get; set; }

        /// <summary>
        /// Meta
        /// </summary>
        public Meta meta { get; set; }
    }
}

namespace Base
{
    /// <summary>
    /// 
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Category ID
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Category Name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Subcategory count
        /// </summary>
        [JsonProperty("children_count")]
        public int ChildrenCount { get; set; }

        /// <summary>
        /// Image link
        /// </summary>
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Parent Category Id
        /// </summary>
        [JsonProperty("parent_id")]
        public int ParentId { get; set; }

        /// <summary>
        /// Is fashion Category
        /// </summary>
        [JsonProperty("fashion")]
        public bool Fashion { get; set; }

        /// <summary>
        /// Layout Mode
        /// </summary>
        [JsonProperty("layout_mode")]
        public string LayoutMode { get; set; }

        /// <summary>
        /// Web url
        /// </summary>
        [JsonProperty("web_uri")]
        public string WebUri { get; set; }

        /// <summary>
        /// Code
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// Path
        /// </summary>
        [JsonProperty("path")]
        public string Path { get; set; }

        /// <summary>
        /// Show specifications
        /// </summary>
        [JsonProperty("show_specifications")]
        public bool ShowSpecifications { get; set; }

        /// <summary>
        /// Manufacturer title
        /// </summary>
        [JsonProperty("manufacturer_title")]
        public string ManufacturerTitle { get; set; }
    }
}
