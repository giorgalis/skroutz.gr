// ***********************************************************************
// Assembly         : skroutz.gr
// Author           : giorgalis
// Created          : 01-07-2017
//
// Last Modified By : giorgalis
// Last Modified On : 01-07-2017
// ***********************************************************************
// <copyright file="Errors.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;

namespace skroutz.gr.Exceptions
{

    /// <summary>
    /// Class Error.
    /// </summary>
    public class Error
    {
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        public string code { get; set; }
        /// <summary>
        /// Gets or sets the messages.
        /// </summary>
        /// <value>The messages.</value>
        public List<string> messages { get; set; }
    }

    /// <summary>
    /// Class Errors.
    /// </summary>
    public class Errors
    {
        /// <summary>
        /// Gets or sets the errors.
        /// </summary>
        /// <value>The errors.</value>
        public List<Error> errors { get; set; }
    }

}
