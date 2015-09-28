using Newtonsoft.Json;

namespace SlApi.General.Models.TravelPlanner.Response
{
    public class TariffZones
    {
        [JsonProperty("$")]
        public ZoneEnum Zone { get; set; }
    }
}