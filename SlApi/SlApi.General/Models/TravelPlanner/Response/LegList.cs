using System.Collections.Generic;
using Newtonsoft.Json;
using SlApi.General.Core;

namespace SlApi.General.Models.TravelPlanner.Response
{
    public class LegList
    {
        /// <summary>
        /// Lista av Leg-objekt
        /// </summary>
        [JsonConverter(typeof(SingleOrArrayConverter<Leg>))]
        public List<Leg> Leg { get; set; }
    }
}