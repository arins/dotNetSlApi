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

        public Sites Sites()
        {
            return HttpClient.DoRequest<Sites>("api2/LineData.json", new SiteDataRequest());
        }

        public Task<Sites> SitesAsync()
        {
            return HttpClient.DoRequestAsync<Sites>("api2/LineData.json", new SiteDataRequest());
        }

        public StopPoints StopPoints()
        {
            return HttpClient.DoRequest<StopPoints>("api2/LineData.json", new StopPointRequest());
        }

        public Task<StopPoints> StopPointsAsync()
        {
            return HttpClient.DoRequestAsync<StopPoints>("api2/LineData.json", new StopPointRequest());
        }
    }
}
