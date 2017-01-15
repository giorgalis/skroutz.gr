// ***********************************************************************
// Assembly         : skroutz.gr
// Author           : giorgalis
// Created          : 01-07-2017
//
// Last Modified By : giorgalis
// Last Modified On : 01-15-2017
// ***********************************************************************
// <copyright file="Favorites.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using skroutz.gr.Shared;
using System.Collections.Generic;

namespace skroutz.gr.Entities.User
{
    /// <summary>
    /// Class Favorite.
    /// </summary>
    public class Favorite
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [have it].
        /// </summary>
        /// <value><c>true</c> if [have it]; otherwise, <c>false</c>.</value>
        [JsonProperty("have_it")]
        public bool HaveIt { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        [JsonProperty("user_id")]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the user notes.
        /// </summary>
        /// <value>The user notes.</value>
        [JsonProperty("user_notes")]
        public object UserNotes { get; set; }

        /// <summary>
        /// Gets or sets the sku identifier.
        /// </summary>
        /// <value>The sku identifier.</value>
        [JsonProperty("sku_id")]
        public int SkuId { get; set; }

        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>The created at.</value>
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the updated at.
        /// </summary>
        /// <value>The updated at.</value>
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets the get absolute threshold.
        /// </summary>
        /// <value>The get absolute threshold.</value>
        [JsonProperty("get_absolute_threshold")]
        public string GetAbsoluteThreshold { get; set; }
    }

    /// <summary>
    /// Class Favorites.
    /// </summary>
    public class Favorites
    {
        /// <summary>
        /// Gets or sets the favorites.
        /// </summary>
        /// <value>The favorites.</value>
        public List<Favorite> favorites { get; set; }
        /// <summary>
        /// Gets or sets the meta.
        /// </summary>
        /// <value>The meta.</value>
        public Meta meta { get; set; }
    }
}
