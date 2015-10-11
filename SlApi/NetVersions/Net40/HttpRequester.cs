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
        /// Gets the response string async from the url
        /// </summary>
        /// <param name="url">url to request from</param>
        /// <returns>return a string in the encoding specified</returns>
        /// <exception cref="RequestException">Throw this exception if any error occurs</exception>
        public async Task<string> GetResponseAsync(Uri url)
        {
            try
            {
                var client = WebRequest.Create(url);
                client.Method = "GET";
                client.Timeout = Timeout;
                var webresponse = client.GetResponseAsync();
                await webresponse.WaitWithTimeoutAsync(Timeout);
                var stream = webresponse.Result.GetResponseStream();
                if (stream == null)
                {
                    throw new RequestException("stream from response is null!");
                }
                using (var streamReader = new StreamReader(stream))
                {
                    return streamReader.ReadToEnd();
                }

            }
            catch (Exception e)
            {
                throw new RequestException("Request failed check inner exception", e);
            }
            
        }


        /// <summary>
        /// Gets the response string from the url
        /// </summary>
        /// <param name="url">url to request from</param>
        /// <returns>return a string in the encoding specified</returns>
        /// <exception cref="RequestException">Throw this exception if any error occurs</exception>
        public string GetResponse(Uri url)
        {
            try
            {

                var client = WebRequest.Create(url);
                
                client.Method = "GET";
                client.Timeout = Timeout;
                var webresponse = client.GetResponseAsync();
                webresponse.WaitWithTimeout(Timeout);
                var stream = webresponse.Result.GetResponseStream();
                if (stream == null)
                {
                    throw new RequestException("stream from response is null!");
                }
                using (var streamReader = new StreamReader(stream))
                {
                    return streamReader.ReadToEnd();
                }

            }
            catch (Exception e)
            {
                throw new RequestException("Request failed check inner exception", e);
            }
        }

    }
}
