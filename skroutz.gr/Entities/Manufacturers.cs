using Newtonsoft.Json;
using skroutz.gr.Shared;
using System.Collections.Generic;

namespace skroutz.gr.Entities
{
    /// <summary>
    /// Root Manufacturer
    /// </summary>
    /// <seealso cref="Base.Manufacturer"/>
    public class RootManufacturer
    {
        /// <summary>
        /// Manufacturer
        /// </summary>
        public Base.Manufacturer manufacturer { get; set; }
    }

    /// <summary>
    /// Manufacturers
    /// </summary>
    /// <seealso cref="Base.Manufacturer"/>
    /// <seealso cref="Meta"/>
    public class Manufacturers
    {
        /// <summary>
        /// Manufacturers
        /// </summary>
        public List<Base.Manufacturer> manufacturers { get; set; }

        /// <summary>
        /// Meta
        /// </summary>
        public Meta meta { get; set; }
    }
}

namespace skroutz.gr.Entities.Base
{
    /// <summary>
    /// Manufacturer
    /// </summary>
    public class Manufacturer
    {
        /// <summary>
        /// Manufacturer Id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Manufacturer name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Image Url
        /// </summary>
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }
    }
}