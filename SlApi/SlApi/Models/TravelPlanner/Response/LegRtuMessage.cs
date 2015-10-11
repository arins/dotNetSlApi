using Newtonsoft.Json;

namespace SlApi.Models.TravelPlanner.Response
{
    public class LegRtuMessage
    {
        [JsonProperty("RTUMessage")]
        public string Message { get; set; }
    }
}