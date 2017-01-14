using skroutz.gr.Shared;
using System.Collections.Generic;

namespace skroutz.gr.Model.User
{
    /// <summary>
    /// Class FavoriteList.
    /// </summary>
    public class FavoriteList
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int id { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string name { get; set; }
        /// <summary>
        /// Gets or sets the category identifier.
        /// </summary>
        /// <value>The category identifier.</value>
        public object category_id { get; set; }
    }

    /// <summary>
    /// Class UserFavorites.
    /// </summary>
    public class UserFavorites
    {
        /// <summary>
        /// Gets or sets the favorite lists.
        /// </summary>
        /// <value>The favorite lists.</value>
        public List<FavoriteList> favorite_lists { get; set; }
        /// <summary>
        /// Gets or sets the meta.
        /// </summary>
        /// <value>The meta.</value>
        public Meta meta { get; set; }
    }
}
