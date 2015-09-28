using System.Collections.Generic;
using Newtonsoft.Json;
using SlApi.General.Core;

namespace SlApi.General.Models.TravelPlanner.Response
{
    public class RtuMessages
    {
        [JsonConverter(typeof(SingleOrArrayConverter<JourneyRtuMessage>))]
        public List<JourneyRtuMessage> RtuMessage { get; set; }

    }
}