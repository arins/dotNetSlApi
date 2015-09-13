using System.Collections.Generic;
using Newtonsoft.Json;
using SlApi.Core;

namespace SlApi.Models.TravelPlanner.Response
{
    public class RtuMessages
    {
        [JsonConverter(typeof(SingleOrArrayConverter<JourneyRtuMessage>))]
        public List<JourneyRtuMessage> RtuMessage { get; set; }

    }
}