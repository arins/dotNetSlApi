using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SlApi.Core
{
    public class Client : IClient
    {
        private IHttpRequester httpRequester;

        public IHttpRequester Requester { get; set; }
        public string EndPoint { get; set; }
        public string ApiToken { get; set; }

        public bool SessionTokenSet
        {
            get { return !string.IsNullOrEmpty(ApiToken); }
        }

        internal DateTime ApiTokenExpires { get; set; }

        public Client()
        {
            EndPoint = "https://api.sl.se/";
        }


        public Client(IHttpRequester httpRequester)
        {
            if (httpRequester == null)
            {
                throw new ArgumentException("Can not pass null IHttpRequest httpRequester");
            }
            Requester = httpRequester;
            EndPoint = "https://api.sl.se/";
        }

        

        internal Uri BuildRequestPath(string path, Arguments arg = null)
        {
            try
            {
                var sb = GetEndPointWithPath(path);
                if (arg != null && arg.Any())
                {
                    arg.BuildAndAppendQueryString(sb);
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
            var resp = Requester.GetResponse(BuildRequestPath(path, arguments));
            var ser = JsonConvert.DeserializeObject<TOut>(resp);
            return ser;
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
            var result = await Requester.GetResponseAsync(BuildRequestPath(path, arguments));
            var p = JsonConvert.DeserializeObject<TOut>(result);
            return p;
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
        public async Task<TOut> DoRequestAsync<TOut>(string path, IConvertableToArgument arguments) where TOut : new()
        {
            if (arguments != null)
            {
                return await DoRequestAsync<TOut>(path, arguments.GetArgument());
            }
            return await DoRequestAsync<TOut>(path);
        }


        private void CheckReuquester()
        {
            if (Requester == null)
            {
                throw new ArgumentNullException("Something went wrong with DI injection" +
                                                " because the Request object was null." +
                                                "If you tried to create your own object you must pass a requester" +
                                                " to the client object when creating one.");
            }
        }


    }
}
