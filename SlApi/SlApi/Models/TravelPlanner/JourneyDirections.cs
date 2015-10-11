using System.Collections.Generic;
using Newtonsoft.Json;
using SlApi.Core;
using SlApi.Models.TravelPlanner.Response;

namespace SlApi.Models.TravelPlanner
{
    public class JourneyDirections
    {
        [JsonConverter(typeof(SingleOrArrayConverter<RouteBase>))]
        public List<RouteBase> Direction { get; set; }
    }
}