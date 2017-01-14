// ***********************************************************************
// Assembly         : skroutz.gr
// Author           : giorgalis
// Created          : 01-08-2017
//
// Last Modified By : giorgalis
// Last Modified On : 01-08-2017
// ***********************************************************************
// <copyright file="SkroutzException.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Net;

namespace skroutz.gr.Exceptions
{
    /// <summary>
    /// Class SkroutzException.
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class SkroutzException : Exception
    {
        /// <summary>
        /// Gets the status code.
        /// </summary>
        /// <value>The status code.</value>
        public HttpStatusCode StatusCode { get; private set; } = HttpStatusCode.OK;
        /// <summary>
        /// Initializes a new instance of the <see cref="SkroutzException"/> class.
        /// </summary>
        public SkroutzException()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SkroutzException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public SkroutzException(string message): base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SkroutzException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public SkroutzException(string message, Exception inner): base(message, inner)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SkroutzException"/> class.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        /// <param name="message">The message.</param>
        public SkroutzException(HttpStatusCode statusCode, string message): base(message)
        {
            this.StatusCode = statusCode;
        }
    }
}
