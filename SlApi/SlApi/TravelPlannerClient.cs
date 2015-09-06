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

       

        public Trip Trip(TripRequest tripRequest)
        {
            return HttpClient.DoRequest<Trip>("api2/TravelplannerV2/trip.json", tripRequest);
        }

        public Task<Trip> TripAsync(TripRequest tripRequest)
        {
            return HttpClient.DoRequestAsync<Trip>("api2/TravelplannerV2/trip.json", tripRequest);
        }
    }
}
