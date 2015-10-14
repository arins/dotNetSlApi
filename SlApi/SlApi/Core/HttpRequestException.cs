using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlApi.Core
{
    public class HttpRequestException : Exception
    {
        public string Response { get; set; }
        public HttpRequestException(string message, string response, Exception exception) : base(message, exception)
        {
            Response = response;
        }
    }
}
