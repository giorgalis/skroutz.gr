using System;
using System.Net;

namespace skroutz.gr
{
    internal class SkroutzException : Exception
    {
        public HttpStatusCode StatusCode { get; private set; } = HttpStatusCode.OK;
        public SkroutzException()
        {

        }

        public SkroutzException(string message): base(message)
        {

        }

        public SkroutzException(string message, Exception inner): base(message, inner)
        {

        }

        public SkroutzException(HttpStatusCode statusCode, string message): base(message)
        {
            this.StatusCode = statusCode;
        }
    }
}
