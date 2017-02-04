using Newtonsoft.Json;
using System.Collections.Generic;

namespace skroutz.gr.Exceptions
{
    /// <summary>
    /// Class Error.
    /// </summary>
    public class Error
    {
        /// <summary>
        /// Gets or sets the Code.
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the Messages.
        /// </summary>
        [JsonProperty("messages")]
        public List<string> Messages { get; set; }
    }
}
