using System;

namespace SlApi.General.Models.StopsAndRoutes.Response
{
    public class Line
    {
        /// <summary>
        /// Unikt identifikationsnummer för linje
        /// </summary>
        public int LineNumber { get; set; }

        /// <summary>
        /// Linjebeteckning
        /// </summary>
        public string LineDesignation { get; set; }

        /// <summary>
        /// Gruppering av linjer för presentation
        /// </summary>
        public string DefaultTransportMode { get; set; }

        /// <summary>
        ///  Trafikslag
        /// </summary>
        public DefaultTransportModeCode DefaultTransportModeCode { get; set; }

        /// <summary>
        /// Senast ändrad
        /// </summary>
        public DateTime LastModifiedUtcDateTime { get; set; }

        /// <summary>
        /// Gäller fr.o.m. datum
        /// </summary>
        public DateTime ExistsFromDate { get; set; }

    }
}