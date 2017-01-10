using Newtonsoft.Json;
using skroutz.gr.Shared;
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

        [JsonProperty("categories")]
        public List<Base.Category> categories { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// 
        [JsonProperty("meta")]
        public Meta Meta { get; set; }
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

        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Category Name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("children_count")]
        public int ChildrenCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("parent_id")]

        public int ParentId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("fashion")]
        public bool Fashion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("layout_mode")]
        public string LayoutMode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("web_uri")]
        public string WebUri { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("path")]
        public string Path { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("show_specifications")]
        public bool ShowSpecifications { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("manufacturer_title")]
        public string ManufacturerTitle { get; set; }
    }
}
