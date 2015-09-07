using System;
using Newtonsoft.Json;
using SlApi.Models.RealtimeInformation.Response;

namespace SlApi.Models.TravelPlanner.Response
{
    public class TripResponse 
    {
        public TripList TripList { get; set; }
    }

    public class TripList : ErrorResponse
    {
        public string NoNamespaceSchemaLocation { get; set; }
        /// <summary>
        /// Duration, restiden inklusive gå sträckan.
        /// </summary>
        [JsonProperty("dur")]
        public int Duruation { get; set; }

        /// <summary>
        /// Antalet byten exklusive vissa gå delresor.
        /// </summary>
        [JsonProperty("chb")]
        public int NumberOfChanges { get; set; }

        /// <summary>
        /// CO2 utsläpp
        /// </summary>
        public string Co2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Leg[] LegList { get; set; }

    }

    public class Leg
    {
        /// <summary>
        /// Sorterings rad
        /// </summary>
        public int Idx { get; set; }


        public string Name { get; set; }
        public TransportModeEnum Type { get; set; }

        [JsonProperty("dir")]
        public string Direction { get; set; }

        public string Linenumber { get; set; }

        public LegDestination Origin { get; set; }

    }

    public class LegDestination
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