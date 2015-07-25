using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
