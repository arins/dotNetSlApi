using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using SlApi.Core;


namespace SlApi
{

    internal class HttpRequester : IHttpRequester
    {
        /// <summary>
        /// The timeout until abort in milliseconds
        /// </summary>
        public int Timeout { get; set; }

        public bool GzipEnabled
        {
            get
            {
                throw new NotSupportedException("This is not supported in .net 4.0");
            }
            set
            {
                throw new NotSupportedException("This is not supported in .net 4.0");
            }
        }

        internal HttpRequester()
        {
            Timeout = 10000;
            
        }

        /// <summary>
        /// Gets the response stream from the url
        /// </summary>
        /// <param name="url">url to request from</param>
        /// <returns>return a string in the encoding specified</returns>
        public StreamAndHeaders GetResponseStream(Uri url)
        {
            var client = WebRequest.Create(url);
            var response = new StreamAndHeaders();
            client.Method = "GET";
            response.SetRequestHeaders(client.Headers);
            client.Timeout = Timeout;
            var webresponse = client.GetResponse();
            response.Stream = webresponse.GetResponseStream();
            response.SetResponseHeaders(webresponse.Headers);
            return response;
        }

        /// <summary>
        /// Gets the response stream async from the url
        /// </summary>
        /// <param name="url">url to request from</param>
        /// <returns>return a string in the encoding specified</returns>
        public async Task<StreamAndHeaders> GetResponseStreamAsync(Uri url)
        {
            var client = WebRequest.Create(url);
            var response = new StreamAndHeaders();
            client.Method = "GET";
            response.SetRequestHeaders(client.Headers);
            client.Timeout = Timeout;
            var webresponse = await client.GetResponseAsync();
            response.Stream = webresponse.GetResponseStream();
            response.SetResponseHeaders(webresponse.Headers);
            return response;
        }

    }
}
