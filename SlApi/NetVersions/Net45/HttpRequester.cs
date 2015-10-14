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

        public bool GzipEnabled { get; set; }

        internal HttpRequester()
        {
            Timeout = 10000;
            GzipEnabled = false;
        }

      

        /// <summary>
        /// Gets the response string async from the url
        /// </summary>
        /// <param name="url">url to request from</param>
        /// <returns>return a string in the encoding specified</returns>
        /// <exception cref="RequestException">Throw this exception if any error occurs</exception>
        public async Task<Stream> GetResponseStreamAsync(Uri url)
        {

            var client = WebRequest.CreateHttp(url);
            if (GzipEnabled)
            {
                client.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

            }
            client.Method = "GET";
            client.Timeout = Timeout;
            var webresponse = await client.GetResponseAsync();
            
            return webresponse.GetResponseStream();
        }


        /// <summary>
        /// Gets the response string async from the url
        /// </summary>
        /// <param name="url">url to request from</param>
        /// <returns>return a string in the encoding specified</returns>
        /// <exception cref="RequestException">Throw this exception if any error occurs</exception>
        public Stream GetResponseStream(Uri url)
        {
            var client = WebRequest.CreateHttp(url);
            if (GzipEnabled)
            {
                client.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            }
            client.Method = "GET";
            client.Timeout = Timeout;
            var webresponse = client.GetResponse();
            return webresponse.GetResponseStream();
        }

    }
}
