using Newtonsoft.Json;

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
        /// 
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        /// 
        [JsonProperty("username")]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the sex.
        /// </summary>
        /// <value>The sex.</value>
        /// <remarks>Possible values: "male" or "female" or null</remarks>
        /// 
        [JsonProperty("sex")]
        public string Sex { get; set; }

        /// <summary>
        /// URI of the avatar image of the user.
        /// </summary>
        /// <value>The avatar.</value>
        /// 
        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        /// <remarks>The type of the account. Possible values: "skroutz", "open_id", "twitter", "facebook", "google"</remarks>
        /// 
        [JsonProperty("type")]
        public string Type { get; set; }
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
        [JsonProperty("user")]
        public User User { get; set; }
    }
}
