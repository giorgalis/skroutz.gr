using Newtonsoft.Json;
using skroutz.gr.Shared;
using System.Collections.Generic;

namespace skroutz.gr.Entities
{
    /// <summary>
    /// Class Reviews.
    /// </summary>
    /// <seealso cref="Base.SKUReview"/>
    /// <seealso cref="Shared.Meta"/>
    public class Reviews
    {
        /// <summary>
        /// Gets or sets the reviews.
        /// </summary>
        /// <value>The reviews.</value>
        public List<Base.SKUReview> reviews { get; set; }
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
    /// Class SKUReview.
    /// </summary>
    public class SKUReview
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        [JsonProperty("user_id")]
        public int UserId { get; }
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
        public int Rating { get; set; }
        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>The created at.</value>
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="SKUReview" /> is demoted.
        /// </summary>
        /// <value><c>true</c> if demoted; otherwise, <c>false</c>.</value>
        [JsonProperty("demoted")]
        public bool Demoted { get; set; }
        /// <summary>
        /// Gets or sets the votes count.
        /// </summary>
        /// <value>The votes count.</value>
        [JsonProperty("votes_count")]
        public int VotesCount { get; set; }
        /// <summary>
        /// Gets or sets the helpful votes count.
        /// </summary>
        /// <value>The helpful votes count.</value>
        [JsonProperty("helpful_votes_count")]
        public int HelpfulVotesCount { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="SKUReview" /> is voted.
        /// </summary>
        /// <value><c>true</c> if voted; otherwise, <c>false</c>.</value>
        [JsonProperty("voted")]
        public bool Voted { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="SKUReview" /> is flagged.
        /// </summary>
        /// <value><c>true</c> if flagged; otherwise, <c>false</c>.</value>
        [JsonProperty("flagged")]
        public bool Flagged { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="SKUReview" /> is helpful.
        /// </summary>
        /// <value><c>true</c> if helpful; otherwise, <c>false</c>.</value>
        [JsonProperty("helpful")]
        public bool Helpful { get; set; }
    }
}
