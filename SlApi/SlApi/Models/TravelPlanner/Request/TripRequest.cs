using System;
using System.Linq;
using System.Text;
using SlApi.Core;

namespace SlApi.Models.TravelPlanner.Request
{
    public class TripRequest : IConvertableToArgument
    {
        public TripRequest()
        {
            Origin = new TripDestination(true);
            Destination = new TripDestination(false);
            ViaIds = new string[0];
            LineInc = new string[0];
            LineExc = new string[0];
        }



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

        /// <summary>
        /// Kan antingen vara siteid eller ett alias, site eller akronym.
        /// Exempel: 300109000, 9000, CST
        /// </summary>
        public string OriginId { get; set; }


        public TripDestination Origin { get; set; }

        public TripDestination Destination { get; set; }

        

        /// <summary>
        /// Kan antingen vara ett site-id, eller ett alias, site eller akronym.
        /// </summary>
        public string DestId { get; set; }

        public string[] ViaIds { get; set; }

        /// <summary>
        /// Tid för via stop. Default=0 betyder att resan kommer att passera via-stoppet.
        /// </summary>
        public int? ViaStopOver { get; set; }

        /// <summary>
        /// Med unsharp=1 kommer svaret innehålla resor från alternative stop-platser i närheten. Default=0
        /// </summary>
        public bool? Unsharp { get; set; }

        /// <summary>
        /// Leta efter den första eller sista resan för dagen. Notera att det här gäller en tidtabellsdag som kan sträcka sig över midnatt.
        /// </summary>
        public bool? SearchFirstLastTrip { get; set; }


        /// <summary>
        /// Max gångavstånd får gång till stop-platser.
        /// </summary>
        public int? MaxWalkDist { get; set; }

        /// <summary>
        /// Stäng av trafiktyper som är tillgängliga som default. 
        /// </summary>
        public bool? UseTrain { get; set; }

        /// <summary>
        /// Stäng av trafiktyper som är tillgängliga som default. 
        /// </summary>
        public bool? UseMetro { get; set; }

        

        /// <summary>
        /// Stäng av trafiktyper som är tillgängliga som default. 
        /// </summary>
        public bool? UseTram { get; set; }

        /// <summary>
        /// Stäng av trafiktyper som är tillgängliga som default. 
        /// </summary>
        public bool? UseBus { get; set; }


        /// <summary>
        /// Stäng av trafiktyper som är tillgängliga som default. Exempel: useTrain=0.
        /// </summary>
        public bool? UseFerry { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool? UseShip { get; set; }

        /// <summary>
        /// Inkludera endast dessa linjer I sökning, suffixlinjer stöds inte. Exempel: lineInc=4,1,38
        /// </summary>
        public string[] LineInc { get; set; }

        /// <summary>
        /// Exkludera dessa linjer i sökningen. Suffixlinjer stöds inte.
        /// Exempel: lineExc=4,1,38
        /// </summary>
        public string[] LineExc { get; set; }
        

        public int? NumTrips { get; set; }

        public Encoding Encoding { get; set; }

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
                result.Add("time", DateTime.Value.ToString("HH:mm"));
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
            if (!string.IsNullOrEmpty(OriginId))
            {
                result.Add("originId", OriginId);
            }

            foreach (var arg in Origin.GetArgument())
            {
                result.Add(arg.Key, arg.Value);
            }
            foreach (var arg in Destination.GetArgument())
            {
                result.Add(arg.Key, arg.Value);
            }

            if (!string.IsNullOrEmpty(DestId))
            {
                result.Add("destId", DestId);
            }
            if (ViaIds.Any())
            {
                var sb = new StringBuilder();
                var counter = 0;
                var length = ViaIds.Length;
                foreach (var viaId in ViaIds)
                {
                    sb.Append(viaId);
                    if (counter + 1 < length)
                    {
                        sb.Append(",");
                    }
                    counter++;
                }
                result.Add("viaId", sb.ToString());
            }
            if (ViaStopOver.HasValue)
            {
                result.Add("viaStopOver", ViaStopOver.Value.ToString());
            }
            if (Unsharp.HasValue)
            {
                result.Add("unsharp", Unsharp.Value ? "1" : "0");
            }

            if (SearchFirstLastTrip.HasValue)
            {
                result.Add("searchFirstLastTrip", SearchFirstLastTrip.Value ? "first" : "last");
            }

            if (MaxWalkDist.HasValue)
            {
                result.Add("maxWalkDist", MaxWalkDist.Value.ToString());
                
            }
            if (UseTrain.HasValue)
            {
                result.Add("useTrain", UseTrain.Value ? "1" : "0");
            }
            if (UseMetro.HasValue)
            {
                result.Add("useMetro", UseTrain.Value ? "1" : "0");
            }

            if (UseTram.HasValue)
            {
                result.Add("useTram", UseTram.Value ? "1" : "0");
            }

            if (UseBus.HasValue)
            {
                result.Add("useBus", UseTram.Value ? "1" : "0");
            }

            if (UseFerry.HasValue)
            {
                result.Add("useFerry", UseTram.Value ? "1" : "0");
            }

            if (UseShip.HasValue)
            {
                result.Add("useShip", UseShip.Value ? "1" : "0");
            }
            if (LineInc.Any())
            {
                var sb = new StringBuilder();
                var counter = 0;
                var length = LineInc.Length;
                foreach (var line in LineInc)
                {
                    sb.Append(line);
                    if (counter + 1 < length)
                    {
                        sb.Append(",");
                    }
                    counter++;
                }
                result.Add("lineInc", sb.ToString());
            }
            if (LineExc.Any())
            {
                var sb = new StringBuilder();
                var counter = 0;
                var length = LineExc.Length;
                foreach (var line in LineExc)
                {
                    sb.Append(line);
                    if (counter + 1 < length)
                    {
                        sb.Append(",");
                    }
                    counter++;
                }
                result.Add("lineExc", sb.ToString());
            }
            if (NumTrips.HasValue)
            {
                result.Add("numTrips", NumTrips.Value.ToString());
            }
            if (Encoding != null)
            {
                result.Add("encoding", Encoding.WebName);
                
            }

            return result;
        }
    }
}