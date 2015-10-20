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
                throw new NotSupportedException("This is not supported in .net silverlight 5.0");
            }
            set
            {
                throw new NotSupportedException("This is not supported in .net silverlight 5.0");
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
        /// <exception cref="RequestException">Throw this exception if any error occurs</exception>
        public StreamAndHeaders GetResponseStream(Uri url)
        {

            var client = WebRequest.Create(url);
            var response = new StreamAndHeaders();
            client.Method = "GET";
            response.SetRequestHeaders(client.Headers);
            var webresponse =  client.GetResponseAsync();
            webresponse.WaitWithTimeout(Timeout);
            response.Stream = webresponse.Result.GetResponseStream();
            return response;
        }

        /// <summary>
        /// Gets the response stream async from the url
        /// </summary>
        /// <param name="url">url to request from</param>
        /// <returns>return a string in the encoding specified</returns>
        /// <exception cref="RequestException">Throw this exception if any error occurs</exception>
        public async Task<StreamAndHeaders> GetResponseStreamAsync(Uri url)
        {
            var client = WebRequest.Create(url);
            var response = new StreamAndHeaders();
            client.Method = "GET";
            response.SetRequestHeaders(client.Headers);
            var webresponse = client.GetResponseAsync();
            await webresponse.WaitWithTimeoutAsync(Timeout);
            response.Stream = webresponse.Result.GetResponseStream();
            return response;
        }

    }
}
