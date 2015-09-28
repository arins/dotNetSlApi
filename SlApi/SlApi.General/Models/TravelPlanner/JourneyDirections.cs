using System.Collections.Generic;
using Newtonsoft.Json;
using SlApi.General.Core;
using SlApi.General.Models.TravelPlanner.Response;

namespace SlApi.General.Models.TravelPlanner
{
    public class JourneyDirections
    {
        [JsonConverter(typeof(SingleOrArrayConverter<RouteBase>))]
        public List<RouteBase> Direction { get; set; }
    }
}