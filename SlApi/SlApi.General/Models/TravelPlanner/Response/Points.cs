using System.Collections.Generic;
using Newtonsoft.Json;
using SlApi.General.Core;

namespace SlApi.General.Models.TravelPlanner.Response
{
    public class Points
    {
        [JsonConverter(typeof(SingleOrArrayConverter<Point>))]
        public List<Point> Point { get; set; }
    }
}