using System;

namespace SlApi.Core
{
    public class RequestException : Exception
    {
        

        public RequestException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public RequestException(string message) : base(message)
        {
        }
    }
}
