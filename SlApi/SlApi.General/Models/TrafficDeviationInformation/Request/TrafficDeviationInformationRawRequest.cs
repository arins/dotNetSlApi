using SlApi.General.Models.StopsAndRoutes.Response;

namespace SlApi.General.Models.TrafficDeviationInformation.Request
{
    public class TrafficDeviationInformationRawRequest
    {
        /// <summary>
        /// Aktuella trafikslag. Tillåtna värden är bus, metro, train och tram. Kommaseparerad sträng.
        /// </summary>
        public DefaultTransportModeCode? TransportMode { get; set; }

        /// <summary>
        /// Max 10 linjer. Kommaseparerad sträng.
        /// </summary>
        public string LineNumber { get; set; }

        /// <summary>
        /// Id för sökt hållplatsområde.
        /// </summary>
        public int? SiteId { get; set; }
    }
}