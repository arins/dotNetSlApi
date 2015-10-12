namespace SlApi.Core
{
    public class BaseService
    {
        public const string Endpoint = "https://api.sl.se/";

        internal IHttpClient HttpClient { get; set; }

        internal BaseService(IHttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        /// <summary>
        /// timeout in milliseconds for the requests
        /// </summary>
        public int Timeout
        {
            get { return HttpClient.Requester.Timeout; }
            set { HttpClient.Requester.Timeout = value; }
        }
        /// <summary>
        /// Implement ISlApiCallback and assign it to the client and you can start catching error 
        /// </summary>
        public ISlApiCallback Callback
        {
            get { return HttpClient.Callback; }
            set { HttpClient.Callback = value; }
        }

        /// <summary>
        /// Sl Api token
        /// </summary>
        public string ApiToken
        {
            get
            {
                if (HttpClient.ApiToken != null)
                {
                    return HttpClient.ApiToken + "";
                }
                return null;

            }
            set
            {

                HttpClient.ApiToken = value;
            }
        }
    }
}
