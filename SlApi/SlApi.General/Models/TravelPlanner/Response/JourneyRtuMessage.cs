using Newtonsoft.Json;

namespace SlApi.General.Models.TravelPlanner.Response
{
    public class JourneyRtuMessage
    {
        [JsonProperty("$")]
        public string Text { get; set; }
    }
}