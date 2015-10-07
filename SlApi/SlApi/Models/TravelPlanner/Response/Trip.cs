using System.Collections.Generic;
using Newtonsoft.Json;
using SlApi.Core;

namespace SlApi.Models.TravelPlanner.Response
{
    /// <summary>
    /// Trip-objektet inneh�ller en lista med Leg-objekt med
    /// den utr�knade resan.
    /// </summary>
    public class Trip
    {
        /// <summary>
        /// Duration, restiden inklusive g� str�ckan.
        /// </summary>
        [JsonProperty("dur")]
        public int Duruation { get; set; }

        /// <summary>
        /// Antalet byten exklusive vissa g� delresor.
        /// </summary>
        [JsonProperty("chb")]
        public int NumberOfChanges { get; set; }

        /// <summary>
        /// CO2 utsl�pp
        /// </summary>
        public string Co2 { get; set; }

        /// <summary>
        /// Leg-objektet �r en del av enresa. Det kanvara antingen en g�ngv�g, 
        /// cykel eller bilv�g eller oftast enresa med bus, t�g, eller annattyp av transportmedel.
        /// </summary>
        public LegList LegList { get; set; }

        /// <summary>
        /// Trip related price information.
        /// </summary>
        [JsonConverter(typeof(SingleOrArrayConverter<PriceInfo>))]
        public List<PriceInfo> PriceInfo { get; set; }
    }
}