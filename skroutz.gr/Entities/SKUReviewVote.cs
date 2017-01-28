using Newtonsoft.Json;

namespace skroutz.gr.Entities
{
    /// <summary>
    /// Class RootSKUReviewVote.
    /// </summary>
    public class RootSKUReviewVote
    {
        /// <summary>
        /// Gets or sets the sku review vote.
        /// </summary>
        /// <value>The sku review vote.</value>
        public Base.SkuReviewVote sku_review_vote { get; set; }
    }
}

namespace skroutz.gr.Entities.Base
{
    /// <summary>
    /// Class SkuReviewVote.
    /// </summary>
    public class SkuReviewVote
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the sku review identifier.
        /// </summary>
        /// <value>The sku review identifier.</value>
        [JsonProperty("sku_review_id")]
        public int SkuReviewId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        [JsonProperty("user_id")]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="SkuReviewVote"/> is helpful.
        /// </summary>
        /// <value><c>true</c> if helpful; otherwise, <c>false</c>.</value>
        [JsonProperty("helpful")]
        public bool Helpful { get; set; }

        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>The created at.</value>
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }
    }
}
