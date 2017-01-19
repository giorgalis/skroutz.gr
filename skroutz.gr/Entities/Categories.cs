using Newtonsoft.Json;
using skroutz.gr.Shared;
using System.Collections.Generic;

namespace skroutz.gr.Entities
{
    /// <summary>
    /// Root Category
    /// </summary>
    public class RootCategory
    {
        /// <summary>
        /// Category
        /// </summary>
        [JsonProperty("category")]
        public Base.Category Category { get; set; }
    }

    /// <summary>
    /// Categories
    /// </summary>
    /// <seealso cref="Base.Category"/>
    /// <seealso cref="Meta"/>
    public class Categories
    {
        /// <summary>
        /// Categories
        /// </summary>
        /// <value>The categories.</value>
        public List<Base.Category> categories { get; set; }

        /// <summary>
        /// Meta
        /// </summary>
        /// <value>The meta.</value>
        public Meta meta { get; set; }
    }
}

namespace skroutz.gr.Entities.Base
{
    /// <summary>
    /// Category
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Category ID
        /// </summary>
        /// <value>The identifier.</value>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Category Name
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Subcategory count
        /// </summary>
        /// <value>The children count.</value>
        [JsonProperty("children_count")]
        public int ChildrenCount { get; set; }

        /// <summary>
        /// Image link
        /// </summary>
        /// <value>The image URL.</value>
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Parent Category Id
        /// </summary>
        /// <value>The parent identifier.</value>
        [JsonProperty("parent_id")]
        public int ParentId { get; set; }

        /// <summary>
        /// Is fashion Category
        /// </summary>
        /// <value><c>true</c> if fashion; otherwise, <c>false</c>.</value>
        [JsonProperty("fashion")]
        public bool Fashion { get; set; }

        /// <summary>
        /// Layout Mode
        /// </summary>
        /// <value>The layout mode.</value>
        [JsonProperty("layout_mode")]
        public string LayoutMode { get; set; }

        /// <summary>
        /// Web url
        /// </summary>
        /// <value>The web URI.</value>
        [JsonProperty("web_uri")]
        public string WebUri { get; set; }

        /// <summary>
        /// Code
        /// </summary>
        /// <value>The code.</value>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// Path
        /// </summary>
        /// <value>The path.</value>
        [JsonProperty("path")]
        public string Path { get; set; }

        /// <summary>
        /// Show specifications
        /// </summary>
        /// <value><c>true</c> if [show specifications]; otherwise, <c>false</c>.</value>
        [JsonProperty("show_specifications")]
        public bool ShowSpecifications { get; set; }

        /// <summary>
        /// Manufacturer title
        /// </summary>
        /// <value>The manufacturer title.</value>
        [JsonProperty("manufacturer_title")]
        public string ManufacturerTitle { get; set; }
    }
}
