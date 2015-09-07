using System.Threading.Tasks;
using SlApi.Core;
using SlApi.Models.TrafficDeviationInformation.Request;
using SlApi.Models.TrafficDeviationInformation.Response;
using SlApi.Models.TrafficInformation.Response;
using SlApi.Models.TravelPlanner.Request;
using SlApi.Models.TravelPlanner.Response;

namespace SlApi
{

    public class TravelPlannerClient : BaseService
    {
        public TravelPlannerClient(IHttpClient httpClient) : base(httpClient)
        {
        }

        public TravelPlannerClient()
            : base(new HttpClient(new HttpRequester()))
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
    }
}
