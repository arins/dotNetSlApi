using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using SlApi.Core;

namespace SlApi.Models.TravelPlanner.Response
{
    public class LegPlace
    {

        /// <summary>
        /// Namn p� start av en delresa. T.ex. �T-centralen�. Om detta �r den f�rsta delresan i en resa 
        /// samt att man i anropet anv�nder parameter: originCoordName s� p�verkar man det som st�r i 
        /// svaret. Skulle man skriva �aaaa� ist�llet f�r �T-centralen� s� skulle man f� tillbaka i 
        /// svaret �aaaa� vid anv�ndandet av den parametern.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ST = Stop/Station
        /// ADR = Address
        /// </summary>
        public LegPlaceTypEnum Type { get; set; }


        /// <summary>
        /// Id f�r angiven plats i delresan. Kan anv�ndas f�r vidare resa fr�n den punkten.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Denna anv�nds i samband med JourneyDetailRef som finns i Leg objektet, f�r att veta fr�n vilken del av listan som �r aktuell f�r delresan.
        /// 
        /// Anv�nds tillsammans med Destination.routeIdx.
        /// </summary>
        [JsonProperty("lon")]
        public double Longitude { get; set; }

        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("routeIdx")]
        public int SortOrding { get; set; }


        /// <summary>
        /// udnerlying time to store
        /// </summary>
        private string _time;

        /// <summary>
        /// Time
        /// </summary>
        [JsonProperty("time")]
        public string Time
        {
            get { return _time; }
            set { _time = DateTimeParsers.ParseApiTime(value); }
        }

        private string _date;
        [JsonProperty("date")]
        public string Date {
            get { return _date; }
            set { _date = DateTimeParsers.ParseApiDate(value); }
        }


        private string _rtTime;

        [JsonProperty("rtTime")]
        public string TimeRealTime {
            get { return _rtTime; }
            set { _rtTime = DateTimeParsers.ParseApiTime(value); }
        }


        private string _rDate;
        [JsonProperty("rtDate")]
        public string TimeRealDate
        {
            get { return _rDate; }
            set { _rDate = DateTimeParsers.ParseApiDate(value); }
        }

        /// <summary>
        /// Inneh�ller en lista p� oskarpa(unsharp) realtidsmeddelanden som g�ller f�r detta Leg-objekt.
        /// </summary>
        [JsonProperty("RTUMessages")]
        public List<LegRtuMessage> RtuMessagesList { get; set; }

        /// <summary>
        /// Inneh�ller en en lista med element av typen Note f�r detta Leg-objekt.
        /// </summary>
        public List<LegNote> Notes { get; set; }
            
        [JsonIgnore]
        public DateTime DateTime
        {
            get { return DateTime.Parse(Date + "T" + Time); }
            set {
                Time = value.ApiTimeToString();
                Date = value.Date.ApiDateToString();
            }
        }

        
        [JsonIgnore]
        public DateTime DateTimeRealTime
        {
            get { return DateTime.Parse(TimeRealDate + "T" + TimeRealTime); }
            set
            {
                TimeRealTime = value.ApiTimeToString();
                TimeRealDate = value.Date.ApiDateToString();
            }
        }

        

    }
}