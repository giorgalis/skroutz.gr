using Newtonsoft.Json;
using System.Collections.Generic;

namespace skroutz.gr.Shared
{
    public class Images
    {
        /// <summary>
        /// Main image
        /// </summary>
        [JsonProperty("main")]
        public string Main { get; set; }

        /// <summary>
        /// Alternative images
        /// </summary>
        [JsonProperty("alternatives")]
        public List<string> Alternatives { get; set; }
    }
}
