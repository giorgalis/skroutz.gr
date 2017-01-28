using Newtonsoft.Json;

namespace skroutz.gr.Shared
{
    /// <summary>
    /// Class Meta.
    /// </summary>
    public class Meta
    {
        /// <summary>
        /// Pagination
        /// </summary>
        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }
    }
}
