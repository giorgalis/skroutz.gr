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
        public int id { get; set; }
        /// <summary>
        /// Gets or sets the flaggable identifier.
        /// </summary>
        /// <value>The flaggable identifier.</value>
        public int flaggable_id { get; set; }
        /// <summary>
        /// Gets or sets the type of the flaggable.
        /// </summary>
        /// <value>The type of the flaggable.</value>
        public string flaggable_type { get; set; }
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        public int user_id { get; set; }
        /// <summary>
        /// Gets or sets the reason.
        /// </summary>
        /// <value>The reason.</value>
        public string reason { get; set; }
        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>The created at.</value>
        public string created_at { get; set; }
        /// <summary>
        /// Gets or sets the updated at.
        /// </summary>
        /// <value>The updated at.</value>
        public string updated_at { get; set; }
    }
}
