using Newtonsoft.Json;
using SlApi.Models.RealtimeInformation.Response;

namespace SlApi.Models.TravelPlanner.Response
{
    public class Leg
    {
        /// <summary>
        /// Sorterings rad
        /// </summary>
        public int Idx { get; set; }


        public string Name { get; set; }
        public TransportModeEnum Type { get; set; }

        [JsonProperty("dir")]
        public string Direction { get; set; }

        public string Linenumber { get; set; }

        public LegPlace Origin { get; set; }

        public LegPlace Destination { get; set; }

        public LegRef JourneyDetailRef { get; set; }

        public LegRef GeometryRef { get; set; }

    }
}