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
        public int id { get; set; }
        /// <summary>
        /// Gets or sets the sku review identifier.
        /// </summary>
        /// <value>The sku review identifier.</value>
        public int sku_review_id { get; set; }
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        public int user_id { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="SkuReviewVote"/> is helpful.
        /// </summary>
        /// <value><c>true</c> if helpful; otherwise, <c>false</c>.</value>
        public bool helpful { get; set; }
        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>The created at.</value>
        public string created_at { get; set; }
    }
}
