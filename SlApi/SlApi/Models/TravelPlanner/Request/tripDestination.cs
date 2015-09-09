using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlApi.Core;

namespace SlApi.Models.TravelPlanner.Request
{
    public class TripDestination : IConvertableToArgument
    {

        private bool IsOrigin { get; set; }

        public TripDestination(bool isOrigin)
        {
            IsOrigin = isOrigin;
        }

        /// <summary>
        /// Ett trippel-id baserat på en koordinat och ett namn för utgångspunkten för resan. Detta kommer att hanteras som en adress i resultatet.
        /// Exempel: originCoordLat=59.347754
        /// originCoordLong=17.883724
        /// originCoordName=Blackebergsplan
        /// </summary>
        public double? CoordLat { get; set; }

        /// <summary>
        /// Ett trippel-id baserat på en koordinat och ett namn för utgångspunkten för resan. Detta kommer att hanteras som en adress i resultatet.
        /// Exempel: originCoordLat=59.347754
        /// originCoordLong=17.883724
        /// originCoordName=Blackebergsplan
        /// </summary>
        public double? CoordLong { get; set; }

        /// <summary>
        /// Ett trippel-id baserat på en koordinat och ett namn för utgångspunkten för resan. Detta kommer att hanteras som en adress i resultatet.
        /// Exempel: originCoordLat=59.347754
        /// originCoordLong=17.883724
        /// originCoordName=Blackebergsplan
        /// </summary>
        public string CoordName { get; set; }

        public Arguments GetArgument()
        {
            var result = new Arguments();
            var prePend = IsOrigin ? "origin" : "dest";
            if (CoordLat.HasValue)
            {
                result.Add(prePend + "CoordLat", CoordLat.Value.ToString());
            }

            if (CoordLong.HasValue)
            {
                result.Add(prePend + "CoordLong", CoordLong.Value.ToString());
            }
            if (!string.IsNullOrEmpty(CoordName))
            {
                result.Add(prePend + "CoordName", CoordName);
            }
            return result;
        }
    }
}
