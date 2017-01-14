// ***********************************************************************
// Assembly         : skroutz.gr
// Author           : giorgalis
// Created          : 01-11-2017
//
// Last Modified By : giorgalis
// Last Modified On : 01-13-2017
// ***********************************************************************
// <copyright file="Reviews.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using skroutz.gr.Shared;
using System.Collections.Generic;

namespace skroutz.gr.Entities
{
    /// <summary>
    /// Class Reviews.
    /// </summary>
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
        public Meta meta { get; set; }
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
        public int id { get; set; }

        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        public int user_id { get; }
        /// <summary>
        /// Gets or sets the review.
        /// </summary>
        /// <value>The review.</value>
        public string review { get; set; }
        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>The rating.</value>
        public int rating { get; set; }
        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>The created at.</value>
        public string created_at { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="SKUReview" /> is demoted.
        /// </summary>
        /// <value><c>true</c> if demoted; otherwise, <c>false</c>.</value>
        public bool demoted { get; set; }
        /// <summary>
        /// Gets or sets the votes count.
        /// </summary>
        /// <value>The votes count.</value>
        public int votes_count { get; set; }
        /// <summary>
        /// Gets or sets the helpful votes count.
        /// </summary>
        /// <value>The helpful votes count.</value>
        public int helpful_votes_count { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="SKUReview" /> is voted.
        /// </summary>
        /// <value><c>true</c> if voted; otherwise, <c>false</c>.</value>
        public bool voted { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="SKUReview" /> is flagged.
        /// </summary>
        /// <value><c>true</c> if flagged; otherwise, <c>false</c>.</value>
        public bool flagged { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="SKUReview" /> is helpful.
        /// </summary>
        /// <value><c>true</c> if helpful; otherwise, <c>false</c>.</value>
        public bool helpful { get; set; }
    }
}
