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

        public int Timeout
        {
            get { return HttpClient.Requester.Timeout; }
            set { HttpClient.Requester.Timeout = value; }
        }

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
