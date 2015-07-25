using System;
using SlApi.Core;

namespace SlApi.Models.RealtimeInformation.Request
{
    [Serializable]
    public class RealtimeDeparturesRequest : IConvertableToArgument
    {



        /// <summary>
        /// Unikt identifikationsnummer för den plats som aktuella avgångar skall hämtas för, t.ex. 9192 för Slussen. Detta id fås från tjänsten SL Platsuppslag.
        /// </summary>
        public int SiteId { get; set; }
        /// <summary>
        /// Hämta avgångar inom önskat tidsfönster. Där tidsfönstret är antalet minuter från och med nu. Max 60.
        /// </summary>
        public int TimeWindow { get; set; }

        public Arguments GetArgument()
        {
            if (TimeWindow < 0 || TimeWindow > 60)
            {
                throw new ArgumentException("Time window must be more than 0 minutes and max 60 minutes");
            }
            var result = new Arguments {{"SiteId", SiteId.ToString()}, {"TimeWindow", TimeWindow.ToString()}};
            return result;
        }
    }
}
