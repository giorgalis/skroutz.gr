using Newtonsoft.Json;

namespace skroutz.gr.Exceptions
{
    /// <summary>
    /// Class BadRequest.
    /// </summary>
    public class BadRequest
    {
        /// <summary>
        /// Gets or sets the Error.
        /// </summary>
        [JsonProperty("error")]
        public string Error { get; set; }
        /// <summary>
        /// Gets or sets the ErrorDescription.
        /// </summary>
        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }
    }
}
