using System.Collections.Generic;
using Newtonsoft.Json;
using SlApi.Core;

namespace SlApi.Models.TravelPlanner.Response
{
    public class JourneyLines
    {
        [JsonConverter(typeof(SingleOrArrayConverter<RouteBase>))]
        public List<RouteBase> Line { get; set; }
    }
}