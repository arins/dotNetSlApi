using System.Collections.Generic;
using Newtonsoft.Json;
using SlApi.Core;

namespace SlApi.Models.TravelPlanner.Response
{
    public class JourneyNames
    {
        [JsonConverter(typeof(SingleOrArrayConverter<RouteBase>))]
        public List<RouteBase> Name { get; set; }
    }
}