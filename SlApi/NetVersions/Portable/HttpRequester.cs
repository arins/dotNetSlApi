using System;
using System.IO;
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
                throw new NotSupportedException("This is not supported in .net portable library");
            }
            set
            {
                throw new NotSupportedException("This is not supported in .net portable library");
            }
        }

        internal HttpRequester()
        {
            Timeout = 10000;
        }

        /// <summary>
        /// Gets the response stream async from the url
        /// </summary>
        /// <param name="url">url to request from</param>
        /// <returns>return a string in the encoding specified</returns>
        /// <exception cref="RequestException">Throw this exception if any error occurs</exception>
        public async Task<Stream> GetResponseStreamAsync(Uri url)
        {
            var client = System.Net.WebRequest.CreateHttp(url);
            client.Method = "GET";
            var webresponse = await client.GetResponseAsync();
            var stream = webresponse.GetResponseStream();
            return stream;
        }


        /// <summary>
        /// Gets the response stream from the url
        /// </summary>
        /// <param name="url">url to request from</param>
        /// <returns>return a string in the encoding specified</returns>
        /// <exception cref="RequestException">Throw this exception if any error occurs</exception>
        public Stream GetResponseStream(Uri url)
        {
            var client = System.Net.WebRequest.CreateHttp(url);
            client.Method = "GET";
            var webresponse = client.GetResponseAsync();
            webresponse.WaitWithTimeout(Timeout);
            var stream = webresponse.Result.GetResponseStream();
            return stream;
        }

    }
}
