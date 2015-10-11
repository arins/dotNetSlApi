using System;

namespace SlApi.Models.RealtimeInformation.Response
{

    /// <summary>
    /// Innehåller själva svarsdata från tjänsten. Se ”Svarsdata” nedan.
    /// </summary>
    public class Departure
    {
        /// <summary>
        /// Anger när realtidsinformationen (DPS) senast uppdaterades.
        /// </summary>
        public DateTime LatestUpdate { get; set; }
        
        /// <summary>
        /// Antal sekunder sedan tidsstämpeln LatestUpdate.
        /// </summary>
        public int DataAge { get; set; }

        /// <summary>
        /// Lista över samtliga bussavgångar för givet siteId (se nedan för detaljer).
        /// </summary>
        public Bus[] Buses { get; set; }

        /// <summary>
        /// Lista över samtliga tunnelbaneavgångar för givet siteId (se nedan för detaljer).
        /// </summary>
        public Metro[] Metros { get; set; }


        /// <summary>
        /// Lista över samtliga pendeltågsavgångar för givet siteId (se nedan för detaljer).
        /// </summary>
        public Train[] Trains { get; set; }


        /// <summary>
        /// Lista över samtliga lokalbaneavgångar för givet siteId (se nedan för detaljer).
        /// </summary>
        public Tram[] Trams { get; set; }

        /// <summary>
        /// Lista över samtliga båtavgångar för givet siteId (se nedan för detaljer).
        /// </summary>
        public Ship[] Ships { get; set; }

        /// <summary>
        /// Lista över hållplatsområdesspecifika avvikelser/störningar. D.v.s. störningar som inte är knutna till en specifik avgång.
        /// </summary>
        public StopPointDeviation[] StopPointDeviations { get; set; }


    }
}
