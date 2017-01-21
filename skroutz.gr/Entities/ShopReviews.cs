using Newtonsoft.Json;
using skroutz.gr.Shared;
using System.Collections.Generic;

namespace skroutz.gr.Entities
{
    /// <summary>
    /// Class ShopReviews.
    /// </summary>
    public class ShopReviews
    {
        /// <summary>
        /// Gets or sets the reviews.
        /// </summary>
        /// <value>The reviews.</value>
        [JsonProperty("reviews")]
        public List<Base.ShopReview> Reviews { get; set; }
        /// <summary>
        /// Gets or sets the meta.
        /// </summary>
        /// <value>The meta.</value>
        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }
}

namespace skroutz.gr.Entities.Base
{
    /// <summary>
    /// Class ShopReview.
    /// </summary>
    public class ShopReview
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        [JsonProperty("user_id")]
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets the review.
        /// </summary>
        /// <value>The review.</value>
        [JsonProperty("review")]
        public string Review { get; set; }
        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>The rating.</value>
        [JsonProperty("rating")]
        public double Rating { get; set; }
        /// <summary>
        /// Gets or sets the shop reply.
        /// </summary>
        /// <value>The shop reply.</value>
        [JsonProperty("shop_reply")]
        public object ShopReply { get; set; }
        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>The created at.</value>
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ShopReview" /> is negative.
        /// </summary>
        /// <value><c>true</c> if negative; otherwise, <c>false</c>.</value>
        [JsonProperty("negative")]
        public bool Negative { get; set; }
        /// <summary>
        /// Gets or sets the reasons.
        /// </summary>
        /// <value>The reasons.</value>
        [JsonProperty("reasons")]
        public List<string> Reasons { get; set; }
    }
}


