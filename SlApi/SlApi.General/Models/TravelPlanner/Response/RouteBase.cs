using Newtonsoft.Json;

namespace SlApi.General.Models.TravelPlanner.Response
{
    public class RouteBase
    {
        public int RouteIdxFrom { get; set; }
        public int RouteIdxTo { get; set; }

        [JsonProperty("$")]
        public string Text { get; set; }
    }
}