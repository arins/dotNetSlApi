using System.Threading.Tasks;
using SlApi.Models.NearbyStations.Request;
using SlApi.Models.NearbyStations.Response;

namespace SlApi
{

    /// <summary>
    /// Med detta API kan du få information om närliggande hållplatser till en försedd plats baserad på lat och long.
    /// </summary>
    public interface INearbyStopsClient
    {
        /// <summary>
        /// Söker efter stationer som är nära en position
        /// </summary>
        /// <param name="nerbyStopsRequest">Parametrar för sökningen. Se objektet för mer information</param>
        /// <returns>Platser som är nära angivne position</returns>
        StopLocations Nearbystops(NearbyStopsRequest nerbyStopsRequest);

        /// <summary>
        /// Söker efter stationer som är nära en position
        /// </summary>
        /// <param name="nerbyStopsRequest">Parametrar för sökningen. Se objektet för mer information</param>
        /// <returns>Platser som är nära angivne position</returns>
        Task<StopLocations> NearbystopsAsync(NearbyStopsRequest nerbyStopsRequest);
    }
}