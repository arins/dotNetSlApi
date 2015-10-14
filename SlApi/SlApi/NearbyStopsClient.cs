using System.Threading.Tasks;
using SlApi.Core;
using SlApi.Models.NearbyStations.Request;
using SlApi.Models.NearbyStations.Response;

namespace SlApi
{
    public class NearbyStopsClient : BaseService, INearbyStopsClient
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
        public NearbyStopsClient(IHttpClient httpClient) : base(httpClient)
        {
        }

        public NearbyStopsClient(string apiToken, string endPoint = Endpoint)
            : base(new HttpClient(endPoint, new HttpRequester(), new UrlHelper()) {
                ApiToken = apiToken
            })
        {
        }

        public NearbyStopsClient()
            : base(new HttpClient(Endpoint, new HttpRequester(), new UrlHelper()))
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
