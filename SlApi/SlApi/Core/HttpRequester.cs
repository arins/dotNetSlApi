using System;
using System.Net;
using System.Threading.Tasks;

namespace SlApi.Core
{
    public class HttpRequester : WebClient, IHttpRequester
    {

        /// <summary>
        /// The timeout until abort in milliseconds
        /// </summary>
        public int Timeout { get; set; }

        public HttpRequester()
        {
            Timeout = 10000;
        }

        /// <summary>
        /// Gets the response string async from the url
        /// </summary>
        /// <param name="url">url to request from</param>
        /// <returns>return a string in the encoding specified</returns>
        /// <exception cref="RequestException">Throw this exception if any error occurs</exception>
        public Task<string> GetResponseAsync(Uri url)
        {
            try
            {
                return DownloadStringTaskAsync(url);
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

                return DownloadString(url);
            }
            catch (Exception e)
            {
                throw new RequestException("Request failed check inner exception", e);
            }
        }

        /// <summary>
        /// Override Timeout
        /// </summary>
        /// <param name="uri">request url</param>
        /// <returns>Webrequest with overriden timeout</returns>
        protected override WebRequest GetWebRequest(Uri uri)
        {
            var w = base.GetWebRequest(uri);
            if (w != null)
            {
                w.Timeout = Timeout;
                return w;
            }
            return null;
        }


    }
}
