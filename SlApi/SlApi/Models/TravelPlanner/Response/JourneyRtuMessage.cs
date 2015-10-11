using Newtonsoft.Json;

namespace SlApi.Models.TravelPlanner.Response
{
    public class JourneyRtuMessage
    {
        [JsonProperty("$")]
        public string Text { get; set; }
    }
}