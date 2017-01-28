using Newtonsoft.Json;

namespace skroutz.gr.Entities.Base
{
    /// <summary>
    /// Class SKUReviewFlag.
    /// </summary>
    public class SKUReviewFlag
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the flaggable identifier.
        /// </summary>
        /// <value>The flaggable identifier.</value>
        [JsonProperty("flaggable_id")]
        public int FlaggableId { get; set; }

        /// <summary>
        /// Gets or sets the type of the flaggable.
        /// </summary>
        /// <value>The type of the flaggable.</value>
        [JsonProperty("flaggable_type")]
        public string FlaggableType { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        [JsonProperty("user_id")]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the reason.
        /// </summary>
        /// <value>The reason.</value>
        [JsonProperty("reason")]
        public string Reason { get; set; }

        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>The created at.</value>
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the updated at.
        /// </summary>
        /// <value>The updated at.</value>
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }
    }
}
