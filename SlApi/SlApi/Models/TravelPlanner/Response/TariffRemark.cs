using Newtonsoft.Json;

namespace SlApi.Models.TravelPlanner.Response
{
    public class TariffRemark
    {
        [JsonProperty("$")]
        public string Remark { get; set; }
    }
}