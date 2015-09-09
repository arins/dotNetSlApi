using Newtonsoft.Json;

namespace SlApi.Models.TravelPlanner.Response
{
    public class TariffZones
    {
        [JsonProperty("$")]
        public ZoneEnum Zone { get; set; }
    }
}