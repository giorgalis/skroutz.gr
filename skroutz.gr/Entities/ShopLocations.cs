using Newtonsoft.Json;
using skroutz.gr.Shared;
using System.Collections.Generic;

namespace skroutz.gr.Entities
{
    /// <summary>
    /// Class ShopLocations.
    /// </summary>
    public class ShopLocations
    {
        /// <summary>
        /// Gets or sets the locations.
        /// </summary>
        /// <value>The locations.</value>
        public List<Base.Location> locations { get; set; }
        /// <summary>
        /// Gets or sets the meta.
        /// </summary>
        /// <value>The meta.</value>
        public Meta meta { get; set; }
    }

}

namespace skroutz.gr.Entities.Base
{
    /// <summary>
    /// Class Location.
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Location" /> is headquarter.
        /// </summary>
        /// <value><c>true</c> if headquarter; otherwise, <c>false</c>.</value>
        [JsonProperty("headquarter")]
        public bool Headquarter { get; set; }
        /// <summary>
        /// Gets or sets the phones.
        /// </summary>
        /// <value>The phones.</value>
        [JsonProperty("phones")]
        public List<string> Phones { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [pickup point].
        /// </summary>
        /// <value><c>true</c> if [pickup point]; otherwise, <c>false</c>.</value>
        [JsonProperty("pickup_point")]
        public bool PickupPoint { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Location" /> is store.
        /// </summary>
        /// <value><c>true</c> if store; otherwise, <c>false</c>.</value>
        [JsonProperty("store")]
        public bool Store { get; set; }
        /// <summary>
        /// Gets or sets the full address.
        /// </summary>
        /// <value>The full address.</value>
        [JsonProperty("full_address")]
        public string FullAddress { get; set; }
        /// <summary>
        /// Gets or sets the format.
        /// </summary>
        /// <value>The format.</value>
        [JsonProperty("format")]
        public string Format { get; set; }
        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        /// <value>The lat.</value>
        [JsonProperty("lat")]
        public string Latitude { get; set; }
        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        /// <value>The LNG.</value>
        [JsonProperty("lng")]
        public string Longitude { get; set; }
        /// <summary>
        /// Gets or sets the information.
        /// </summary>
        /// <value>The information.</value>
        [JsonProperty("info")]
        public string Info { get; set; }
    }
}