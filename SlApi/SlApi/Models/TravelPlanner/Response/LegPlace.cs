using System;
using Newtonsoft.Json;

namespace SlApi.Models.TravelPlanner.Response
{
    public class LegPlace
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Id { get; set; }

        [JsonProperty("lon")]
        public double Longitude { get; set; }

        [JsonProperty("lat")]
        public double Latitude { get; set; }
        [JsonProperty("routeIdx")]
        public int SortOrding { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonIgnore]
        public DateTime DateTime
        {
            get { return DateTime.Parse(Date + "T" + Time); }
            set {
                Time = value.ToString("HH:mm");
                Date = value.Date.ToString("yyyy-MM-dd");
            }
        }
    }
}