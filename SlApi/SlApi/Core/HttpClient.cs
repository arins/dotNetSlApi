﻿using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace SlApi.Core
{
    internal class HttpClient : IHttpClient
    {

        public IHttpRequester Requester { get; set; }

        public IUrlHelper UrlHelper { get; set; }

        internal string EndPoint { get; set; }
        public string ApiToken { get; set; }

        public bool ApiTokenSet => !string.IsNullOrEmpty(ApiToken);

        internal DateTime ApiTokenExpires { get; set; }

        internal HttpClient(string endPoint, IHttpRequester httpRequester, IUrlHelper helper, ISlApiCallback callback = null)
        {
            if (httpRequester == null)
            {
                throw new ArgumentException("Can not pass null IHttpRequest httpRequester");
            }
            if (string.IsNullOrEmpty(endPoint))
            {
                throw new ArgumentException("endpoint must be set!");
            }
            if (helper == null)
            {
                throw new ArgumentException("urlhelper must be set");
            }
            EndPoint = endPoint;
            Requester = httpRequester;
            UrlHelper = helper;
            
        }

        

        internal Uri BuildRequestPath(string path, Arguments arg = null)
        {
            try
            {
                var sb = GetEndPointWithPath(path);
                if (arg != null && arg.Any())
                {
                    arg.BuildAndAppendQueryString(UrlHelper,sb);
                }
                AppendAccessToken(sb);
                return new Uri(sb.ToString());
            }
            catch (Exception e)
            {
                var exp = new RequestPathBuildException("Something went wrong when build request path", e);
                throw exp;
            }
        }

        private void AppendAccessToken(StringBuilder sb)
        {
            sb.Append("key=");
            sb.Append(ApiToken);
        }

        private StringBuilder GetEndPointWithPath(string path)
        {
            var sb = new StringBuilder();
            sb.Append(EndPoint);
            sb.Append(path);
            sb.Append(path.EndsWith("/") ? "?" : "/?");
            return sb;
        }

        /// <summary>
        /// Makes a request to endpoint with path a specific path and arguments. Deserilizes the data recivied to type TOut
        /// </summary>
        /// <typeparam name="TOut">Type to deserilize to</typeparam>
        /// <param name="path">Path to request aginst</param>
        /// <param name="arguments">arguments which will be deserilized to querystring</param>
        /// <returns>Deserilized data of type TOut from response</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="RequestException"></exception>
        public TOut DoRequest<TOut>(string path, Arguments arguments = null) where TOut : new()
        {
            CheckReuquester();

            Stream stream = null;
            try
            {

                stream = Requester.GetResponseStream(BuildRequestPath(path, arguments));
                var serializer = new JsonSerializer();
                using (var sr = new StreamReader(stream))
                {
                    using (var jsonTextReader = new JsonTextReader(sr))
                    {
                        var result = serializer.Deserialize<TOut>(jsonTextReader);
                        
                        return result;
                    }
                }
            }
            catch (Exception exception)
            {
                var response = "";
                if (stream != null)
                {
                    var sr = new StreamReader(stream);
                    response = sr.ReadToEnd();
                }
                throw new HttpRequestException("Something wrong when requesting ", response, exception);
            }

        }

        public TOut DoRequest<TOut>(string path, IConvertableToArgument arguments) where TOut : new()
        {
            if (arguments != null)
            {
                return DoRequest<TOut>(path, arguments.GetArgument());
            }
            return DoRequest<TOut>(path);
        }


        /// <summary>
        /// Makes a request to api endpoint with path a specific path and arguments. 
        /// Deserilizes the data recivied to type TOut. This operation is done sync
        /// </summary>
        /// <typeparam name="TOut">Type to deserilize to</typeparam>
        /// <param name="path">Path to request aginst</param>
        /// <param name="arguments">arguments which will be deserilized to querystring</param>
        /// <returns>Deserilized data of type TOut from response</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="RequestException"></exception>
        public async Task<TOut> DoRequestAsync<TOut>(string path, Arguments arguments = null) where TOut : new()
        {
            CheckReuquester();
            var url = BuildRequestPath(path, arguments);
            var stream = await Requester.GetResponseStreamAsync(url);
            var serializer = new JsonSerializer();
            using (var sr = new StreamReader(stream))
            {
                using (var jsonTextReader = new JsonTextReader(sr))
                {
                    return serializer.Deserialize<TOut>(jsonTextReader);
                }
            }
        }


        /// <summary>
        /// Makes a request to api endpoint with path a specific path and arguments. 
        /// Deserilizes the data recivied to type TOut. This operation is done sync
        /// </summary>
        /// <typeparam name="TOut">Type to deserilize to</typeparam>
        /// <param name="path">Path to request aginst</param>
        /// <param name="arguments">arguments which will be deserilized to querystring</param>
        /// <returns>Deserilized data of type TOut from response</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="RequestException"></exception>
        public Task<TOut> DoRequestAsync<TOut>(string path, IConvertableToArgument arguments) where TOut : new()
        {
            if (arguments != null)
            {
                return DoRequestAsync<TOut>(path, arguments.GetArgument());
            }
            return DoRequestAsync<TOut>(path);
        }


        private void CheckReuquester()
        {
            if (Requester == null)
            {
                throw new ArgumentNullException("Something went wrong with DI injection" +
                                                " because the Request object was null." +
                                                "If you tried to create your own object you must pass a requester" +
                                                " to the HttpClient object when creating one.");
            }
        }


    }

    
}
