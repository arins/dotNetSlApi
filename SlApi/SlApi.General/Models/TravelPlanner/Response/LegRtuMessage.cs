using Newtonsoft.Json;

namespace SlApi.General.Models.TravelPlanner.Response
{
    public class LegRtuMessage
    {
        [JsonProperty("RTUMessage")]
        public string Message { get; set; }
    }
}