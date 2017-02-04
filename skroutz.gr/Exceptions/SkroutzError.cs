using Newtonsoft.Json;
using System.Collections.Generic;

namespace skroutz.gr.Exceptions
{
    /// <summary>
    /// Class SkroutzError.
    /// </summary>
    public class SkroutzError
    {
        /// <summary>
        /// Gets or sets the Errors.
        /// </summary>
        [JsonProperty("errors")]
        public List<Error> Errors { get; set; }
    }
}
