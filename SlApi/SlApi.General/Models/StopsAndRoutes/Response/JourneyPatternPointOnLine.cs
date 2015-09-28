using System;

namespace SlApi.General.Models.StopsAndRoutes.Response
{
    public class JourneyPatternPointOnLine : BaseResponse
    {
        /// <summary>
        /// Unikt identifikationsnummer för linjes
        /// </summary>
        public int LineNumber { get; set; }

        /// <summary>
        /// Linjeriktning
        /// </summary>
        public int DirectionCode { get; set; }

        /// <summary>
        /// Unikt identifikationsnummer för stoppställe
        /// </summary>
        public int JourneyPatternPointNumber { get; set; }

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
