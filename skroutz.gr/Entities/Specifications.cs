// ***********************************************************************
// Assembly         : skroutz.gr
// Author           : giorgalis
// Created          : 01-09-2017
//
// Last Modified By : giorgalis
// Last Modified On : 01-12-2017
// ***********************************************************************
// <copyright file="Specifications.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;

namespace skroutz.gr.Entities
{
    /// <summary>
    /// Class Specifications.
    /// </summary>
    public class Specifications
    {
        /// <summary>
        /// Gets or sets the specifications.
        /// </summary>
        /// <value>The specifications.</value>
        public List<Base.Specification> specifications { get; set; }
    }
}

namespace skroutz.gr.Entities.Base
{
    /// <summary>
    /// Class Specification.
    /// </summary>
    public class Specification
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
        /// Gets or sets the values.
        /// </summary>
        /// <value>The values.</value>
        public List<object> values { get; set; }
        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>The order.</value>
        public int order { get; set; }
        /// <summary>
        /// Gets or sets the unit.
        /// </summary>
        /// <value>The unit.</value>
        public string unit { get; set; }
    }
}
