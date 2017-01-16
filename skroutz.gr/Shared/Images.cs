using Newtonsoft.Json;
using System.Collections.Generic;

namespace skroutz.gr.Shared
{
    /// <summary>
    /// Class Images.
    /// </summary>
    public class Images
    {
        /// <summary>
        /// Main image
        /// </summary>
        /// <value>The main.</value>
        [JsonProperty("main")]
        public string Main { get; set; }

        /// <summary>
        /// Alternative images
        /// </summary>
        /// <value>The alternatives.</value>
        [JsonProperty("alternatives")]
        public List<string> Alternatives { get; set; }
    }
}
