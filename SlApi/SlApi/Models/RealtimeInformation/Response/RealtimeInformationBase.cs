using System;

namespace SlApi.Models.RealtimeInformation.Response
{
    public class RealtimeInformationBase : TransportModeContainer
    {

        /// <summary>
        /// Id för sökt hållplatsområde.
        /// </summary>
        public int SiteId { get; set; }
        

        /// <summary>
        /// Hållplatsnamn
        /// </summary>
        public string StopAreaName { get; set; }
        /// <summary>
        /// Id för aktuell hållplats.
        /// </summary>
        public int StopAreaNumber { get; set; }

        /// <summary>
        /// Id för aktuellt stoppställe.
        /// </summary>
        public int StopPointNumber { get; set; }
        /// <summary>
        /// Linjebeteckning/nummer.
        /// </summary>
        public string LineNumber { get; set; }
        /// <summary>
        /// Slutstation för avgången.
        /// </summary>
        public string Destination { get; set; }

        /// <summary>
        /// Avgångstid enligt tidtabell.
        /// </summary>
        public DateTime TimeTabledDateTime { get; set; }

        /// <summary>
        /// Förväntad avgångstid.Om det finns tillhörande störning med tillräckligt hög 
        /// prioritet så kan denna ha null/tomt värde. Detta fram till ett par minuter innan avgång.
        /// </summary>
        public DateTime ExpectedDateTime { get; set; }
        /// <summary>
        /// Avgångstid för presentation. Kan anta formaten x min, HH:mm eller Nu.
        ///  Om det finns tillhörande störning med tillräckligt hög prioritet så kan
        ///  denna ha värdet ”-”. Detta fram till ett par minuter innan avgång.
        /// </summary>
        public string DisplayTime { get; set; }

        /// <summary>
        /// Innehåller typen ”Deviation” nedan. Denna kan vara tom, eller innehålla 1 till flera avvikelser.
        /// </summary>
        public Deviation[] Deviations { get; set; }

        /// <summary>
        /// Reseriktnings-id.
        /// </summary>
        public int JourneyDirection { get; set; }
            
    }
}