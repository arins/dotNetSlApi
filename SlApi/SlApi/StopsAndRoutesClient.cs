using System.Threading.Tasks;
using SlApi.Core;
using SlApi.Models.RealtimeInformation.Request;
using SlApi.Models.RealtimeInformation.Response;
using SlApi.Models.StopsAndRoutes.Request;
using SlApi.Models.StopsAndRoutes.Response;

namespace SlApi
{
    public class StopsAndRoutesClient : BaseService, IStopsAndRoutesClient
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

        public Lines Lines()
        {
            return HttpClient.DoRequest<Lines>("api2/LineData.json", new LinesRequest());
        }

        public Task<Lines> LinesAsync()
        {
            return HttpClient.DoRequestAsync<Lines>("api2/LineData.json", new LinesRequest());
        }

        public TransportModes TransportModes()
        {
            return HttpClient.DoRequest<TransportModes>("api2/LineData.json", new TransportModeRequest());
        }

        public Task<TransportModes> TransportModesAsync()
        {
            return HttpClient.DoRequestAsync<TransportModes>("api2/LineData.json", new TransportModeRequest());
        }

        public JourneyPatternPointOnLines JourneyPaternPointOnLine()
        {
            return HttpClient.DoRequest<JourneyPatternPointOnLines>("api2/LineData.json", new JourneyPatternPointOnLineRequest());
        }

        public Task<JourneyPatternPointOnLines> JourneyPaternPointOnLineAsync()
        {
            return HttpClient.DoRequestAsync<JourneyPatternPointOnLines>("api2/LineData.json", new JourneyPatternPointOnLineRequest());
        }
    }

    
}
