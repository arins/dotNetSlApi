using System;
using System.Threading.Tasks;

namespace SlApi.Core
{
    public interface IHttpRequester
    {
        /// <summary>
        /// Gets the response string async from the url
        /// </summary>
        /// <param name="url">url to request from</param>
        /// <returns>return a string in the encoding specified</returns>
        /// <exception cref="RequestException">Throw this exception if any error occurs</exception>
        Task<string> GetResponseAsync(Uri url);

        /// <summary>
        /// Gets the response string from the url
        /// </summary>
        /// <param name="url">url to request from</param>
        /// <returns>return a string in the encoding specified</returns>
        /// <exception cref="RequestException">Throw this exception if any error occurs</exception>
        string GetResponse(Uri url);


        /// <summary>
        /// The timeout until abort in milliseconds
        /// </summary>
        int Timeout { get; set; }

        bool GzipEnabled { get; set; }
    }
}
