using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SlApi.Core
{
    public class StreamAndHeaders
    {
        public Stream Stream { get; set; }
        public Dictionary<string, string> RequestHeaders { get; set; }
        public Dictionary<string, string> ResponseHeaders { get; set; }

        public void SetRequestHeaders(WebHeaderCollection headers)
        {
            RequestHeaders = new Dictionary<string, string>();
            foreach (var key in headers.AllKeys)
            {
                RequestHeaders[key] = headers[key];
            }
        }

        public void SetResponseHeaders(WebHeaderCollection headers)
        {
            ResponseHeaders = new Dictionary<string, string>();
            foreach (var key in headers.AllKeys)
            {
                ResponseHeaders[key] = headers[key];
            }
        }

        public string GetRequestHeadersAsString()
        {
            var sb = new StringBuilder();
            foreach (var key in RequestHeaders.Keys)
            {
                sb.Append(key);
                sb.Append(": ");
                sb.Append(RequestHeaders[key]);
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public string GetResponsetHeadersAsString()
        {
            var sb = new StringBuilder();
            foreach (var key in ResponseHeaders.Keys)
            {
                sb.Append(key);
                sb.Append(": ");
                sb.Append(ResponseHeaders[key]);
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
