using System.Threading.Tasks;
using SlApi.General;
using SlApi.General.Core;
using SlApi.General.Models.NearbyStations.Request;
using SlApi.General.Models.NearbyStations.Response;

namespace SlApi
{
    public class NearbyStopsClient : BaseService, INearbyStopsClient
    {
        public NearbyStopsClient(IHttpClient httpClient) : base(httpClient)
        {
        }

        public NearbyStopsClient()
            : base(new HttpClient("https://api.sl.se/", new HttpRequester(), new UrlHelper()))
        {
        }
        public NearbyStopsClient(string endPoint)
            : base(new HttpClient(endPoint, new HttpRequester(), new UrlHelper()))
        {
        }

        public StopLocations Nearbystops(NearbyStopsRequest nerbyStopsRequest)
        {
            return HttpClient.DoRequest<StopLocations>("api2/nearbystops.json", nerbyStopsRequest);
        }

        public Task<StopLocations> NearbystopsAsync(NearbyStopsRequest nerbyStopsRequest)
        {
            return HttpClient.DoRequestAsync<StopLocations>("api2/nearbystops.json", nerbyStopsRequest);
        }
    }
}
