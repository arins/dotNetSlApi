using System;
using Newtonsoft.Json;
using SlApi.Core;

namespace SlApi.Models.TravelPlanner.Response
{
    public class Stop
    {
        public string Name { get; set; }

        public string Id { get; set; }


        [JsonProperty("lon")]
        public double Longitude { get; set; }

        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("routeIdx")]
        public int SortOrder { get; set; }

        [JsonProperty("arrTime")]
        public string ArrivalTime { get; set; }


        [JsonProperty("arrDate")]
        public string ArrivalDate { get; set; }

        [JsonProperty("depTime")]
        public string DepartureTime { get; set; }

        [JsonProperty("depDate")]
        public string DepartureDate { get; set; }



        [JsonIgnore]
        public DateTime? ArrivalDateTime
        {
            get
            {
                return ArrivalDate == null || ArrivalTime == null
                    ? (DateTime?) null
                    : DateTime.Parse(ArrivalDate + "T" + ArrivalTime);
            }
            set
            {
                if (value.HasValue)
                {
                    ArrivalTime = value.ApiTimeToString();
                    ArrivalDate = value.ApiDateToString();
                }
            }
        }

        [JsonIgnore]
        public DateTime? DepartureDateTime
        {
            get
            {
                return DepartureDate == null || DepartureTime == null
                    ? (DateTime?) null
                    : DateTime.Parse(DepartureDate + "T" + DepartureTime);
            }
            set
            {
                if (value.HasValue)
                {
                    DepartureTime = value.ApiTimeToString();
                    DepartureDate = value.ApiDateToString();
                }
            }
        }


    }
}