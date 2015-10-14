using System;
using System.IO;
using System.Threading.Tasks;

namespace SlApi.Core
{
    public interface IHttpRequester
    {
       


        /// <summary>
        /// Gets the response stream from the url
        /// </summary>
        /// <param name="url">url to request from</param>
        /// <returns>return a string in the encoding specified</returns>
        /// <exception cref="RequestException">Throw this exception if any error occurs</exception>
        Stream GetResponseStream(Uri url);


        /// <summary>
        /// Gets the response stream async from the url
        /// </summary>
        /// <param name="url">url to request from</param>
        /// <returns>return a string in the encoding specified</returns>
        /// <exception cref="RequestException">Throw this exception if any error occurs</exception>
        Task<Stream> GetResponseStreamAsync(Uri url);

        /// <summary>
        /// The timeout until abort in milliseconds
        /// </summary>
        int Timeout { get; set; }

        bool GzipEnabled { get; set; }
        
    }
}
