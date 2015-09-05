using System.Threading.Tasks;
using SlApi.Models.NearbyStations.Request;
using SlApi.Models.NearbyStations.Response;

namespace SlApi
{
    public interface INearbyStops
    {
        StopLocations Nearbystops(NearbyStopsRequest nerbyStopsRequest);
        Task<StopLocations> NearbystopsAsync(NearbyStopsRequest nerbyStopsRequest);
    }
}