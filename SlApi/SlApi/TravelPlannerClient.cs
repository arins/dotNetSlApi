using System.Threading.Tasks;
using SlApi.Core;

using SlApi.Models.TravelPlanner.Request;
using SlApi.Models.TravelPlanner.Response;

namespace SlApi
{

    public class TravelPlannerClient : BaseService, ITravelPlannerClient
    {

        public bool GzipEnabled
        {
            get
            {
                return HttpClient.Requester.GzipEnabled;

            }
            set
            {
                HttpClient.Requester.GzipEnabled = value;
            }
        }

        public bool EnableDebugInformationInException
        {
            get { return HttpClient.EnableDebugInformationInException; }
            set { HttpClient.EnableDebugInformationInException = value; }
        }

        public TravelPlannerClient(IHttpClient httpClient) : base(httpClient)
        {
        }


        public TravelPlannerClient(string apiToken, string endPoint = Endpoint)
            : base(new HttpClient(endPoint, new HttpRequester(), new UrlHelper()) {
                ApiToken = apiToken
            })
        {
        }

        public TravelPlannerClient()
            : base(new HttpClient("https://api.sl.se/", new HttpRequester(), new UrlHelper()))
        {
        }

        public TripResponse Trip(TripRequest tripRequest)
        {
            return HttpClient.DoRequest<TripResponse>("api2/TravelplannerV2/trip.json", tripRequest);
        }

        public Task<TripResponse> TripAsync(TripRequest tripRequest)
        {
            return HttpClient.DoRequestAsync<TripResponse>("api2/TravelplannerV2/trip.json", tripRequest);
        }

        public JourneyDetailResponse JourneyDetail(JourneyRequest journeyRequest)
        {
            return HttpClient.DoRequest<JourneyDetailResponse>("api2/TravelplannerV2/journeydetail.json", journeyRequest);
        }


        public Task<JourneyDetailResponse> JourneyDetailAsync(JourneyRequest journeyRequest)
        {
            return HttpClient.DoRequestAsync<JourneyDetailResponse>("api2/TravelplannerV2/journeydetail.json", journeyRequest);

        }

        public Task<GeometryResponse> GeometryAsync(GeometryRequest geometryRequest)
        {
            return HttpClient.DoRequestAsync<GeometryResponse>("api2/TravelplannerV2/geometry.json", geometryRequest);
        }

        public GeometryResponse Geometry(GeometryRequest geometryRequest)
        {
            return HttpClient.DoRequest<GeometryResponse>("api2/TravelplannerV2/geometry.json", geometryRequest);
        }
    }
}
