using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;

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
            set { _time = ParseTime(value); }
        }

        private string _date;
        [JsonProperty("date")]
        public string Date {
            get { return _date; }
            set { _date = ParseDate(value); }
        }


        private string _rtTime;

        [JsonProperty("rtTime")]
        public string TimeRealTime {
            get { return _rtTime; }
            set { _rtTime = ParseTime(value); }
        }


        private string _rDate;
        [JsonProperty("rtDate")]
        public string TimeRealDate
        {
            get { return _rDate; }
            set { _rDate = ParseDate(value); }
        }

        /// <summary>
        /// Inneh�ller en lista p� oskarpa(unsharp) realtidsmeddelanden som g�ller f�r detta Leg-objekt.
        /// </summary>
        [JsonProperty("RTUMessages")]
        public List<RtuMessage> RtuMessagesList { get; set; }

        /// <summary>
        /// Inneh�ller en en lista med element av typen Note f�r detta Leg-objekt.
        /// </summary>
        public List<LegNote> Notes { get; set; }
            
        [JsonIgnore]
        public DateTime DateTime
        {
            get { return DateTime.Parse(Date + "T" + Time); }
            set {
                Time = value.ToString("HH:mm");
                Date = value.Date.ToString("yyyy-MM-dd");
            }
        }

        
        [JsonIgnore]
        public DateTime DateTimeRealTime
        {
            get { return DateTime.Parse(TimeRealDate + "T" + TimeRealTime); }
            set
            {
                TimeRealTime = value.ToString("HH:mm");
                TimeRealDate = value.Date.ToString("yyyy-MM-dd");
            }
        }

        private string ParseTime(string value)
        {
            try
            {
                var result = DateTime.ParseExact(value, "HH:mm", CultureInfo.CurrentCulture);
                return result.ToString("HH:mm");
            }
            catch (Exception ex)
            {
                throw new ArgumentException("not a valid time", ex);
            }
        }

        private string ParseDate(string value)
        {
            try
            {
                var result = DateTime.ParseExact(value, "yyyy-MM-dd", CultureInfo.CurrentCulture);
                return result.ToString("yyyy-MM-dd");
            }
            catch (Exception ex)
            {
                throw new ArgumentException("not a valid date", ex);
            }
        }

    }

    public class LegNote
    {
        /// <summary>
        /// 
        /// </summary>
        public string Note { get; set; }
    }

    public class RtuMessage
    {
        [JsonProperty("RTUMessage")]
        public string Message { get; set; }
    }
}