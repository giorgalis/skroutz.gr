using Newtonsoft.Json;
using skroutz.gr.Shared;
using System.Collections.Generic;

namespace skroutz.gr.Entities
{
    /// <summary>
    /// Class RootManufacturer.
    /// </summary>
    /// <seealso cref="Base.Manufacturer"/>
    public class RootManufacturer
    {
        /// <summary>
        /// Manufacturer
        /// </summary>
        [JsonProperty("manufacturer")]
        public Base.Manufacturer Manufacturer { get; set; }
    }

    /// <summary>
    /// Manufacturers
    /// </summary>
    /// <seealso cref="Base.Manufacturer"/>
    /// <seealso cref="Shared.Meta"/>
    public class Manufacturers
    {
        /// <summary>
        /// Class Manufacturers.
        /// </summary>
        public List<Base.Manufacturer> manufacturers { get; set; }

        /// <summary>
        /// Meta
        /// </summary>
        [JsonProperty("meta")]
        public Meta Meta { get; set; }
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