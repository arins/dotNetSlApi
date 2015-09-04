using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlApi.Models.StopsAndRoutes.Response
{
    public class StopPoint
    {
        /// <summary>
        /// Unikt identifikationsnummer för stoppställe
        /// </summary>
        public int StopPointNumber { get; set; }

        /// <summary>
        /// Namn på stoppställe
        /// </summary>
        public string StopPointName { get; set; }

        /// <summary>
        /// Number för StopArea
        /// Ett stoppställe ingår endast i en StopArea
        /// </summary>
        public int StopAreaNumber { get; set; }

        /// <summary>
        /// Koordinat i WGS84-format
        /// </summary>
        public double LocationNorthingCoordinate { get; set; }

        /// <summary>
        /// Koordinat i WGS84-format
        /// </summary>
        public double LocationEastingCoordinate { get; set; }

        /// <summary>
        /// Taxezon. A, B eller C
        /// Om SLs taxa inte gäller är taxezon null
        /// </summary>
        public string ZoneShortName { get; set; }

        /// <summary>
        /// Användning av hållplatsen. BUSSTERM, TRAMSTN,METROSTN, RAILWSTN, SHIPBER eller FERRYBER
        /// </summary>
        public StopAreaTypeCode StopAreaTypeCode { get; set; }

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
