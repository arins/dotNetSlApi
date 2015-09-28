using SlApi.General.Models.StopsAndRoutes.Response;

namespace SlApi.General.Models.TrafficDeviationInformation.Request
{
    public class TrafficDeviationInformationRawRequest
    {
        /// <summary>
        /// Aktuella trafikslag. Till�tna v�rden �r bus, metro, train och tram. Kommaseparerad str�ng.
        /// </summary>
        public DefaultTransportModeCode? TransportMode { get; set; }

        /// <summary>
        /// Max 10 linjer. Kommaseparerad str�ng.
        /// </summary>
        public string LineNumber { get; set; }

        /// <summary>
        /// Id f�r s�kt h�llplatsomr�de.
        /// </summary>
        public int? SiteId { get; set; }
    }
}