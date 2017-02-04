using System;
using System.Net;

namespace skroutz.gr.Exceptions
{
    /// <summary>
    /// Class SkroutzException.
    /// </summary>
    /// <seealso cref="Exception" />
    public class SkroutzException : Exception
    {
        /// <summary>
        /// Gets the status code.
        /// </summary>
        /// <value>The status code.</value>
        public HttpStatusCode StatusCode { get; private set; } = HttpStatusCode.OK;

        /// <summary>
        /// Gets the web exception.
        /// </summary>
        /// <value>The web exception.</value>
        public WebException webException { get; private set; } = null;

        /// <summary>
        /// Gets the error.
        /// </summary>
        /// <value>The error.</value>
        public SkroutzError SkroutzError { get; private set; } = null;
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
        /// <param name="message">The message that describes the error.</param>
        /// <param name="inner">The inner Exception.</param>
        public SkroutzException(string message, Exception inner): base(message, inner)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SkroutzException" /> class.
        /// </summary>
        /// <param name="webException">The web exception.</param>
        /// <param name="statusCode">The status code.</param>
        /// <param name="message">The message that describes the error.</param>
        public SkroutzException(WebException webException, HttpStatusCode statusCode, string message, SkroutzError error) : base(message, webException)
        {
            this.webException = webException;
            this.StatusCode = statusCode;
            this.SkroutzError = error;
        }
    }
}
