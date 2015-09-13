using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlApi.Core;

namespace SlApi.Models.NearbyStations.Request
{
    public class NearbyStopsRequest : IConvertableToArgument
    {
        /// <summary>
        /// Lat (WGS, decimal degree), ex 59.293611
        /// </summary>
        public double OriginCoordLat { get; set; }

        /// <summary>
        /// Long (WGS, decimal degree), ex 18.083056
        /// </summary>
        public double OriginCoordLong { get; set; }

        /// <summary>
        /// Maximalt antal resultat som önskas. 9 är default, max är 1000.
        /// </summary>
        public int? MaxResults { get; set; }

        /// <summary>
        /// Radie i meter för det cirkulära området kring koordinaten som
        /// närliggande hållplatser skall hämtas ut för. 1000 m är defaultvärde, max är 2000 m.
        /// </summary>
        public int? Radius { get; set; }

        public Language? Lang { get; set; }

        public Arguments GetArgument()
        {
            var result = new Arguments
            {
                {"originCoordLat", OriginCoordLat.ToString()},
                {"originCoordLong", OriginCoordLong.ToString()}
            };
            if (MaxResults.HasValue)
            {
                result.Add("maxResults", MaxResults.Value.ToString());
            }
            if (Radius.HasValue)
            {
                result.Add("radius", Radius.Value.ToString());
            }
            if (Lang.HasValue)
            {
                result.Add("lang", Lang.Value.ToNearbyStationsRequestString());
            }
            return result;
        }

        
    }
}
