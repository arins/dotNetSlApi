using Newtonsoft.Json;

namespace SlApi.Models.TravelPlanner.Response
{
    public class RouteBase
    {
        public int RouteIdxFrom { get; set; }
        public int RouteIdxTo { get; set; }

        [JsonProperty("$")]
        public string Text { get; set; }
    }
}