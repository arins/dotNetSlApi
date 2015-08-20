namespace SlApi.Core
{
    public class BaseService
    {
         internal IHttpClient HttpClient { get; set; }


         internal BaseService(IHttpClient httpClient)
        {
            HttpClient = httpClient;
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
