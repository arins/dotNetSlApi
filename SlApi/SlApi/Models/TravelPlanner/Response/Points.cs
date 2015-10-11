using System.Collections.Generic;
using Newtonsoft.Json;
using SlApi.Core;

namespace SlApi.Models.TravelPlanner.Response
{
    public class Points
    {
        [JsonConverter(typeof(SingleOrArrayConverter<Point>))]
        public List<Point> Point { get; set; }
    }
}