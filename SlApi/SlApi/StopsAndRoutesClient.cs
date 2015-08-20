using System.Threading.Tasks;
using SlApi.Core;
using SlApi.Models.RealtimeInformation.Request;
using SlApi.Models.RealtimeInformation.Response;

namespace SlApi
{
    public class StopsAndRoutesClient : BaseService
    {
        public StopsAndRoutesClient(IHttpClient httpClient)
            : base(httpClient)
        {
        }

        public StopsAndRoutesClient() : base(new HttpClient(new HttpRequester()))
        {
            
        }

        
    }
}
