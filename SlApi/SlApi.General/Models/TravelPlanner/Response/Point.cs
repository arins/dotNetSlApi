using Newtonsoft.Json;

namespace SlApi.General.Models.TravelPlanner.Response
{
    public class Point
    {
        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("lon")]
        public double Longitude { get; set; }
    }
}