using System;
using System.Runtime.Serialization;

namespace DataAccessLayer
{
    [Serializable]
    internal class HttpStatusException : Exception
    {
        public HttpStatusException()
        {
        }

        public HttpStatusException(string message) : base(message)
        {
        }

        public HttpStatusException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected HttpStatusException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}