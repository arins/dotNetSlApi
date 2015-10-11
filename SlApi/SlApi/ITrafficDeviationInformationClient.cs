using System.Threading.Tasks;
using SlApi.Models.TrafficDeviationInformation.Request;
using SlApi.Models.TrafficDeviationInformation.Response;

namespace SlApi
{
    /// <summary>
    /// Med detta API kan du få fram information om aktuella och planerade störningar i SL-trafiken. 
    /// Med API ‘et kan du ställa frågor om störningar på till exempel en viss linje eller ett visst trafikslag. Svaret består av störningsmeddelanden med viss metainformation.
    /// För att se informationen som returneras av detta API, se storningsinformation.sl.se.
    /// Om ingen av parametrarna ”TransportMode”, ”LineNumber” och ”SiteId” skickas med anropet skickas samtliga avvikelser tillbaks som svar.
    /// </summary>
    public interface ITrafficDeviationInformationClient
    {
        TrafficDeviationInformation GetTrafficDeviationInformation(TrafficDeviationInformationRequest request);
        Task<TrafficDeviationInformation> GetTrafficDeviationInformationAsync(TrafficDeviationInformationRequest request);

        TrafficDeviationInformationRaw GetTrafficDeviationInformationRaw(TrafficDeviationInformationRawRequest request);

        Task<TrafficDeviationInformationRaw> GetTrafficDeviationInformationRawAsync(
            TrafficDeviationInformationRawRequest request);
    }
}