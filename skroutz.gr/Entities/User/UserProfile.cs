// ***********************************************************************
// Assembly         : skroutz.gr
// Author           : giorgalis
// Created          : 01-06-2017
//
// Last Modified By : giorgalis
// Last Modified On : 01-10-2017
// ***********************************************************************
// <copyright file="UserProfile.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace skroutz.gr.Model.User
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
        public sex sex { get; set; }
        /// <summary>
        /// Gets or sets the avatar.
        /// </summary>
        /// <value>The avatar.</value>
        public string avatar { get; set; }
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public type type { get; set; }
    }

    /// <summary>
    /// Enum sex
    /// </summary>
    public enum sex
    {
        /// <summary>
        /// Male
        /// </summary>
        male,
        /// <summary>
        /// Female
        /// </summary>
        female,
        /// <summary>
        /// Not set
        /// </summary>
        @null
    }

    /// <summary>
    /// Enum type
    /// </summary>
    public enum type
    {
        /// <summary>
        /// The skroutz
        /// </summary>
        skroutz,
        /// <summary>
        /// The open identifier
        /// </summary>
        open_id,
        /// <summary>
        /// The twitter
        /// </summary>
        twitter,
        /// <summary>
        /// The facebook
        /// </summary>
        facebook,
        /// <summary>
        /// The google
        /// </summary>
        google
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
