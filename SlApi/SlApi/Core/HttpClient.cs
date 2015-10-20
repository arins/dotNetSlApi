using System;
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

        public bool EnableDebugInformationInException { get; set; }

        public bool ApiTokenSet => !string.IsNullOrEmpty(ApiToken);

        internal DateTime ApiTokenExpires { get; set; }

        internal HttpClient(string endPoint, IHttpRequester httpRequester, IUrlHelper helper)
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
                var sb = GetEndPointAsStringBuilder();
                sb.Append(path);
                if (arg != null && arg.Any())
                {
                    
                    sb.Append(path.EndsWith("/") ? "?" : "/?");
                    arg.BuildAndAppendQueryString(UrlHelper,sb);
                }
                AppendAccessToken(sb, arg?.Count ?? 0);
                return new Uri(sb.ToString());
            }
            catch (Exception e)
            {
                var exp = new RequestPathBuildException("Something went wrong when build request path", e);
                throw exp;
            }
        }

        private void AppendAccessToken(StringBuilder sb, int arguments)
        {
            if (ApiTokenSet)
            {
                if (arguments == 0)
                {
                    sb.Append("?");
                }
                sb.Append("key=");
                sb.Append(ApiToken);
            }
        }

        private StringBuilder GetEndPointAsStringBuilder()
        {
            var sb = new StringBuilder();
            sb.Append(EndPoint);
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
            string response = null;
            StreamAndHeaders data = null;
            try
            {

                var url = BuildRequestPath(path, arguments);
                data = Requester.GetResponseStream(url);
                if (!EnableDebugInformationInException)
                {
                    return SerializeStream<TOut>(data.Stream);
                }
                return SerializeStream<TOut>(data.Stream, out response);
            }
            catch (Exception exception)
            {
                throw new HttpRequestException("Something wrong when requesting ",
                    response,
                    data?.GetResponsetHeadersAsString(),
                    data?.GetRequestHeadersAsString(),
                    exception);
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

        private TOut SerializeStream<TOut>(Stream stream)
        {
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

        private TOut SerializeStream<TOut>(Stream stream, out string response)
        {
            var sr = new StreamReader(stream);
            response = sr.ReadToEnd();
            return JsonConvert.DeserializeObject<TOut>(response);
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
            
            string response = null;
            StreamAndHeaders data = null;
            try
            {
                var url = BuildRequestPath(path, arguments);
                data = await Requester.GetResponseStreamAsync(url);
                if (!EnableDebugInformationInException)
                {
                    return SerializeStream<TOut>(data.Stream);
                }
                return SerializeStream<TOut>(data.Stream, out response);
            }
            catch (Exception exception)
            {
                throw new HttpRequestException("Something wrong when requesting ",
                    response,
                    data?.GetResponsetHeadersAsString(),
                    data?.GetRequestHeadersAsString(),
                    exception);
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
