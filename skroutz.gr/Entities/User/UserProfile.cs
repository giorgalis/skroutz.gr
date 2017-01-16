namespace skroutz.gr.Entities.User
{
    /// <summary>
    /// Class User.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int id { get; set; }
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string username { get; set; }
        /// <summary>
        /// Gets or sets the sex.
        /// </summary>
        /// <value>The sex.</value>
        /// <remarks>Possible values: "male" or "female" or null</remarks>
        public string sex { get; set; }
        /// <summary>
        /// URI of the avatar image of the user.
        /// </summary>
        /// <value>The avatar.</value>
        public string avatar { get; set; }
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        /// <remarks>The type of the account. Possible values: "skroutz", "open_id", "twitter", "facebook", "google"</remarks>
        public string type { get; set; }
    }

    /// <summary>
    /// Class UserProfile.
    /// </summary>
    public class UserProfile
    {
        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>The user.</value>
        public User user { get; set; }
    }
}
