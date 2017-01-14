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
        public List<Base.ShopReview> reviews { get; set; }
        /// <summary>
        /// Gets or sets the meta.
        /// </summary>
        /// <value>The meta.</value>
        public Meta meta { get; set; }
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
        public int id { get; set; }
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        public int user_id { get; set; }
        /// <summary>
        /// Gets or sets the review.
        /// </summary>
        /// <value>The review.</value>
        public string review { get; set; }
        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>The rating.</value>
        public double rating { get; set; }
        /// <summary>
        /// Gets or sets the shop reply.
        /// </summary>
        /// <value>The shop reply.</value>
        public object shop_reply { get; set; }
        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>The created at.</value>
        public string created_at { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ShopReview" /> is negative.
        /// </summary>
        /// <value><c>true</c> if negative; otherwise, <c>false</c>.</value>
        public bool negative { get; set; }
        /// <summary>
        /// Gets or sets the reasons.
        /// </summary>
        /// <value>The reasons.</value>
        public List<string> reasons { get; set; }
    }
}


