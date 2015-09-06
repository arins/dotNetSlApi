using System;
using System.Threading.Tasks;
using SlApi.Core;
using SlApi.Models.TrafficDeviationInformation.Request;
using SlApi.Models.TrafficDeviationInformation.Response;
using SlApi.Models.TrafficInformation.Response;

namespace SlApi
{

    public class TravelPlannerClient : BaseService
    {
        public TravelPlannerClient(IHttpClient httpClient) : base(httpClient)
        {
        }

        public TravelPlannerClient()
            : base(new HttpClient(new HttpRequester()))
        {
        }

       

        public Trip Trip(TripRequest tripRequest)
        {
            return HttpClient.DoRequest<Trip>("api2/TravelplannerV2/trip.json", tripRequest);
        }

        public Task<Trip> TripAsync(TripRequest tripRequest)
        {
            return HttpClient.DoRequestAsync<Trip>("api2/TravelplannerV2/trip.json", tripRequest);
        }
    }

    public class Trip 
    {
        
    }

    public class TripRequest : IConvertableToArgument
    {
        /// <summary>
        /// Språk i svar, default sv
        /// </summary>
        public Language? Lang { get; set; }

        /// <summary>
        /// Datum. Exempel 2014-08-23. date=2014-08-23. Default idag.
        /// Tid. Exempel time=19:06. Default nu.
        /// </summary>
        public DateTime? DateTime { get; set; }

        /// <summary>
        /// Som standard/default söker man efter tiden som man vill 
        /// att resan skall avgå. Genom att sätta searchForArrival till true,
        /// så söker man istället resor baserat på tiden man vill komma
        /// fram. Default=false.
        /// </summary>
        public bool? SearchForArrival { get; set; }

        /// <summary>
        /// Begränsa antalet byten. Default obegränsad
        /// </summary>
        public int? NumberOfChanges { get; set; }

        /// <summary>
        /// Minimum bytestid
        /// </summary>
        public int? MinimumChangeTime { get; set; }

         

        public Arguments GetArgument()
        {
            var result = new Arguments();
            if (Lang.HasValue)
            {
                result.Add("lang", Lang.Value.ToTripLanguageString());
            }
            if (DateTime.HasValue)
            {
                result.Add("date", DateTime.Value.Date.ToString("yyyy-MM-dd"));
                result.Add("time", DateTime.Value.ToString("hh:mm"));
            }
            if (SearchForArrival.HasValue)
            {
                result.Add("searchForArrival", SearchForArrival.Value ? "1" : "0");
            }
            if (NumberOfChanges.HasValue)
            {
                result.Add("numChg", NumberOfChanges.Value.ToString());
            }
            if (MinimumChangeTime.HasValue)
            {
                result.Add("minChgTime", MinimumChangeTime.Value.ToString());
            }
            
            return result;
        }
    }
}
