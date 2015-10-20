using System.Threading.Tasks;
using SlApi.Core;
using SlApi.Models.StopsAndRoutes.Request;
using SlApi.Models.StopsAndRoutes.Response;

namespace SlApi
{
    public class StopsAndRoutesClient : BaseService, IStopsAndRoutesClient
    {
        public bool GzipEnabled
        {
            get
            {
                return HttpClient.Requester.GzipEnabled;
            }
            set { HttpClient.Requester.GzipEnabled = value; }
        }
        public bool EnableDebugInformationInException
        {
            get { return HttpClient.EnableDebugInformationInException; }
            set { HttpClient.EnableDebugInformationInException = value; }
        }

        public StopsAndRoutesClient(IHttpClient httpClient)
            : base(httpClient)
        {
        }

        public StopsAndRoutesClient(string endPoint)
            : base(new HttpClient(endPoint, new HttpRequester(), new UrlHelper()))
        {
        }
        public StopsAndRoutesClient()
            : base(new HttpClient("https://api.sl.se/", new HttpRequester(), new UrlHelper()))
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
