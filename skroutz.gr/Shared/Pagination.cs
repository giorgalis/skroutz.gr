using Newtonsoft.Json;

namespace skroutz.gr.Shared
{
    /// <summary>
    /// Class Pagination.
    /// </summary>
    public class Pagination
    {
        /// <summary>
        /// Gets or sets the total results.
        /// </summary>
        /// <value>The total results.</value>
        [JsonProperty("total_results")]
        public int TotalResults { get; set; }

        /// <summary>
        /// Gets or sets the total pages.
        /// </summary>
        /// <value>The total pages.</value>
        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        /// <value>The page.</value>
        [JsonProperty("page")]
        public int Page { get; set; }

        /// <summary>
        /// Gets or sets the per.
        /// </summary>
        /// <value>The per.</value>
        [JsonProperty("per")]
        public int Per { get; set; }
    }
}
