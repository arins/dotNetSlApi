using System.Threading.Tasks;
using SlApi.Core;
using SlApi.Models.RealtimeInformation.Request;
using SlApi.Models.RealtimeInformation.Response;
using SlApi.Models.StopsAndRoutes.Request;
using SlApi.Models.StopsAndRoutes.Response;

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

        public SiteDataResponse SiteData()
        {
            return HttpClient.DoRequest<SiteDataResponse>("api2/LineData.json", new LineDataRequest());
        }

        public Task<SiteDataResponse> SiteDataAsync()
        {
            return HttpClient.DoRequestAsync<SiteDataResponse>("api2/LineData.json", new LineDataRequest());
        }
    }
}
