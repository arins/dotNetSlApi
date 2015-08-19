namespace SlApi.Core
{
    public class BaseService
    {
         internal IClient Client { get; set; }


         internal BaseService(IClient client)
        {
            Client = client;
        }

         public string ApiToken
        {
            get
            {
                if (Client.ApiToken != null)
                {
                    return Client.ApiToken + "";
                }
                return null;

            }
            set
            {

                Client.ApiToken = value;
            }
        }
    }
}
