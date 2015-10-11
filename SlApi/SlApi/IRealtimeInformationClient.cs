using System.Threading.Tasks;
using SlApi.Models.RealtimeInformation.Request;
using SlApi.Models.RealtimeInformation.Response;

namespace SlApi
{
    /// <summary>
    /// Realtidsinformation gällande buss, tunnelbana, pendeltåg, lokalbana och båtar. Detta API innehåller liknande information som SL Realtidsinformation, 
    /// men gör det möjligt att komma åt informationen via en metod istället för olika metoder beroende på trafikslag. Dessutom innehåller svaret 
    /// störningsinformation när sådan finns för avgångarna/hållplatserna som presenteras.
    /// </summary>
    public interface IRealtimeInformationClient
    {
        /// <summary>
        /// Realtidsinformation gällande buss, tunnelbana, pendeltåg och lokalbana.
        /// Detta API innehåller liknande information som SL Realtidsinformation, 
        /// men gör det möjligt att komma åt informationen via en metod istället för olika metoder beroende på trafikslag.
        /// Dessutom innehåller svaret störningsinformation när sådan finns för avgångarna/hållplatserna som presenteras.
        /// </summary>
        /// <param name="realTimeSearchRequest">Parametrar för sökningen</param>
        /// <returns></returns>
        DepartureResponse RealtimeDepartures(RealtimeDeparturesRequest realTimeSearchRequest);

        /// <summary>
        /// Realtidsinformation gällande buss, tunnelbana, pendeltåg och lokalbana.
        /// Detta API innehåller liknande information som SL Realtidsinformation, 
        /// men gör det möjligt att komma åt informationen via en metod istället för olika metoder beroende på trafikslag.
        /// Dessutom innehåller svaret störningsinformation när sådan finns för avgångarna/hållplatserna som presenteras
        /// </summary>
        /// <param name="realTimeSearchRequest">Parametrar för sökningen</param>
        /// <returns></returns>
        Task<DepartureResponse> RealtimeDeparturesAsync(RealtimeDeparturesRequest realTimeSearchRequest);
    }
}