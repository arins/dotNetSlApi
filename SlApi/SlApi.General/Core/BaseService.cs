namespace SlApi.General.Core
{
    public class BaseService
    {
         public IHttpClient HttpClient { get; set; }


         public BaseService(IHttpClient httpClient)
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
