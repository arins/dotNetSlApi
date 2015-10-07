using System.Collections.Generic;
using Newtonsoft.Json;
using SlApi.Core;

namespace SlApi.Models.TravelPlanner.Response
{
    public class JourneyTypes
    {
        [JsonConverter(typeof(SingleOrArrayConverter<RouteBase>))]
        public List<RouteBase> Type { get; set; }
    }
}