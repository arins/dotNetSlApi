using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlApi.Models.StopsAndRoutes.Response
{
    public class StopsAndRoutesBaseResponse<T>
    {
        /// <summary>
        /// Senast ändrad. Uppdateras normalt sett bara en gång per dygn
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Anger typen av datamodellen som svaret innehåller:
        /// Site, StopPoint, Line, JourneyPatternPointOfLine, TransportMode
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Container-objekt som innehåller typad data
        /// </summary>
        public T[] Result { get; set; }
    }
}
