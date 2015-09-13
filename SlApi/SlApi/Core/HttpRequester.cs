using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SlApi.Core
{
    public class HttpRequester : IHttpRequester
    {
        public HttpRequester()
        {
            GzipEnabled = false;
        }

        /// <summary>
        /// The timeout until abort in milliseconds
        /// </summary>
        public int Timeout { get; set; }

        public bool GzipEnabled { get; set; }

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
                var client = new System.Net.Http.HttpClient {Timeout = new TimeSpan(0, 0, 0, 0, Timeout)};
                if (GzipEnabled)
                {
                    client.DefaultRequestHeaders.AcceptEncoding.Add(StringWithQualityHeaderValue.Parse("gzip, deflate"));
                }
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
               
                var client = new System.Net.Http.HttpClient {Timeout = new TimeSpan(0, 0, 0, 0, Timeout)};
                if (GzipEnabled)
                {
                    client.DefaultRequestHeaders.AcceptEncoding.Add(StringWithQualityHeaderValue.Parse("gzip, deflate"));
                }
                var asyncResult = client.GetStringAsync(url);
                asyncResult.WaitUntilDoneWithTimeoutAsync(Timeout);
                return asyncResult.Result;

            }
            catch (Exception e)
            {
                throw new RequestException("Request failed check inner exception", e);
            }
        }

    }
}
