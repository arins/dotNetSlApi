using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SlApi.Core
{
    public class HttpRequester : IHttpRequester
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
                var client = new HttpClient {Timeout = new TimeSpan(0, 0, 0, 0, Timeout)};
                return client.GetStringAsync(url);
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
               
                var client = new HttpClient {Timeout = new TimeSpan(0, 0, 0, 0, Timeout)};
                
                var asyncResult = client.GetStringAsync(url);
                asyncResult.Wait();
                return asyncResult.Result;

            }
            catch (Exception e)
            {
                throw new RequestException("Request failed check inner exception", e);
            }
        }

    }
}
