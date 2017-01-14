// ***********************************************************************
// Assembly         : skroutz.gr
// Author           : giorgalis
// Created          : 01-06-2017
//
// Last Modified By : giorgalis
// Last Modified On : 01-14-2017
// ***********************************************************************
// <copyright file="ShopLocations.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using skroutz.gr.Shared;
using System.Collections.Generic;

namespace skroutz.gr.Entities
{
    /// <summary>
    /// Class ShopLocations.
    /// </summary>
    public class ShopLocations
    {
        /// <summary>
        /// Gets or sets the locations.
        /// </summary>
        /// <value>The locations.</value>
        public List<Base.Location> locations { get; set; }
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
    /// Class Location.
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int id { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Location" /> is headquarter.
        /// </summary>
        /// <value><c>true</c> if headquarter; otherwise, <c>false</c>.</value>
        public bool headquarter { get; set; }
        /// <summary>
        /// Gets or sets the phones.
        /// </summary>
        /// <value>The phones.</value>
        public List<string> phones { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [pickup point].
        /// </summary>
        /// <value><c>true</c> if [pickup point]; otherwise, <c>false</c>.</value>
        public bool pickup_point { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Location" /> is store.
        /// </summary>
        /// <value><c>true</c> if store; otherwise, <c>false</c>.</value>
        public bool store { get; set; }
        /// <summary>
        /// Gets or sets the full address.
        /// </summary>
        /// <value>The full address.</value>
        public string full_address { get; set; }
        /// <summary>
        /// Gets or sets the format.
        /// </summary>
        /// <value>The format.</value>
        public string format { get; set; }
        /// <summary>
        /// Gets or sets the lat.
        /// </summary>
        /// <value>The lat.</value>
        public string lat { get; set; }
        /// <summary>
        /// Gets or sets the LNG.
        /// </summary>
        /// <value>The LNG.</value>
        public string lng { get; set; }
        /// <summary>
        /// Gets or sets the information.
        /// </summary>
        /// <value>The information.</value>
        public string info { get; set; }
    }
}