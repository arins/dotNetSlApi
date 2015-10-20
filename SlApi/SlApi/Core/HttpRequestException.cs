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
        public string ResponseHeaders { get; set; }

        public string RequestHeaders { get; set; }
        public HttpRequestException(string message, 
            string response, 
            string responseHeaders, 
            string requestHeaders,  
            Exception exception) : base(message, exception)
        {
            Response = response;
            ResponseHeaders = responseHeaders;
            RequestHeaders = requestHeaders;
        }
    }
}
