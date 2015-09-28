using Newtonsoft.Json;

namespace SlApi.General.Models.TravelPlanner.Response
{
    public class TariffRemark
    {
        [JsonProperty("$")]
        public string Remark { get; set; }
    }
}