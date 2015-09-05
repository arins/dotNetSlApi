using System;
using SlApi.Models.RealtimeInformation.Response;

namespace SlApi.Models.TrafficDeviationInformation.Response
{
    public class TrafficDeviation
    {
        /// <summary>
        /// När ärendet blev publicerad.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Boolean som indikerar om ärendet är en huvudnyhet.
        /// </summary>
        public bool MainNews { get; set; }

        /// <summary>
        /// Förslag på sorteringsordning av ärendena.
        /// </summary>
        public int SortOrder { get; set; }

        /// <summary>
        /// Rubrik.
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// Detaljer, samma som presenteras på webbplatsen för resp. ärende.
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// Ett beskrivande alias för ScopeElements.
        /// </summary>
        public string Scope { get; set; }

        /// <summary>
        /// Ärendets id.
        /// </summary>
        public string DevCaseGid { get; set; }

        /// <summary>
        /// Anger aktuell version för ärendet.
        /// </summary>
        public int DevMessageVersionNumber { get; set; }

        /// <summary>
        /// Uppräkning av vilka linjer eller hållplatser ärendet gäller för.
        /// </summary>
        public string ScopeElements { get; set; }

        /// <summary>
        /// När ärendet börjar vara aktivt.
        /// </summary>
        public DateTime FromDateTime { get; set; }

        /// <summary>
        /// När ärendet slutar att vara aktivt.
        /// </summary>
        public DateTime UpToDateTime { get; set; }

        /// <summary>
        /// Senast ärendet blev uppdaterat.
        /// </summary>
        public DateTime Updated { get; set; }

        /// <summary>
        /// Prioriteringsordning för ärendet.
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// Linje där ärendet är gällande.
        /// </summary>
        public string LineNumber { get; set; }

        /// <summary>
        /// Id för hållplatsområde. Kan vara tom.
        /// </summary>
        public string SiteId { get; set; }

        /// <summary>
        /// Trafikslag för ärendet.
        /// </summary>
        public TransportModeEnum TransportMode { get; set; }


    }
}