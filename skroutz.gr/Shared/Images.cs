using Newtonsoft.Json;
using System.Collections.Generic;

namespace skroutz.gr.Shared
{
    public class Images
    {
        [JsonProperty("main")]
        public string Main { get; set; }

        [JsonProperty("alternatives")]
        public List<string> Alternatives { get; set; }
    }
}
