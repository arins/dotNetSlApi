using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlApi.Core;
using SlApi.Models.NearbyStations.Request;
using SlApi.Models.NearbyStations.Response;

namespace SlApi
{
    public class NearbyStopsClient : BaseService, INearbyStops
    {
        public NearbyStopsClient(IHttpClient httpClient) : base(httpClient)
        {
        }

        public NearbyStopsClient()
            : base(new HttpClient(new HttpRequester()))
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
