using System.Collections.Generic;
using Newtonsoft.Json;
using SlApi.General.Core;

namespace SlApi.General.Models.TravelPlanner.Response
{
    public class JourneyNames
    {
        [JsonConverter(typeof(SingleOrArrayConverter<RouteBase>))]
        public List<RouteBase> Name { get; set; }
    }
}