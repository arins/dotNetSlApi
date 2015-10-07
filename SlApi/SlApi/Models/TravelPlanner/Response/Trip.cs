using System.Collections.Generic;
using Newtonsoft.Json;
using SlApi.Core;

namespace SlApi.Models.TravelPlanner.Response
{
    /// <summary>
    /// Trip-objektet innehåller en lista med Leg-objekt med
    /// den uträknade resan.
    /// </summary>
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
        /// Leg-objektet är en del av enresa. Det kanvara antingen en gångväg, 
        /// cykel eller bilväg eller oftast enresa med bus, tåg, eller annattyp av transportmedel.
        /// </summary>
        public LegList LegList { get; set; }

        /// <summary>
        /// Trip related price information.
        /// </summary>
        [JsonConverter(typeof(SingleOrArrayConverter<PriceInfo>))]
        public List<PriceInfo> PriceInfo { get; set; }
    }
}