using Newtonsoft.Json;

namespace SlApi.Models.TravelPlanner.Response
{
    public class TripList : ErrorResponse
    {
        public string NoNamespaceSchemaLocation { get; set; }
       public Trip[] Trip { get; set; }

    }

    public class Trip
    {
        /// <summary>
        /// Duration, restiden inklusive gå sträckan.
        /// </summary>
        [JsonProperty("dur")]
        public int Duruation { get; set; }

        /// <summary>
        /// Antalet byten exklusive vissa gå delresor.
        /// </summary>
        [JsonProperty("chb")]
        public int NumberOfChanges { get; set; }

        /// <summary>
        /// CO2 utsläpp
        /// </summary>
        public string Co2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public LegList LegList { get; set; }

        public PriceInfo PriceInfo { get; set; }
    }
}