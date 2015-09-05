using System.Threading.Tasks;
using SlApi.Core;
using SlApi.Models.TrafficDeviationInformation.Request;
using SlApi.Models.TrafficDeviationInformation.Response;
using SlApi.Models.TrafficInformation.Response;

namespace SlApi
{

    public class TrafficInformationClient : BaseService, ITrafficInformationClient
    {
        public TrafficInformationClient(IHttpClient httpClient) : base(httpClient)
        {
        }

        public TrafficInformationClient()
            : base(new HttpClient(new HttpRequester()))
        {
        }

       

        public TrafficInformation GetTrafficInformation()
        {
            return HttpClient.DoRequest<TrafficInformation>("api2/trafficsituation.json");
        }

        public Task<TrafficInformation> GetTrafficInformationAsync()
        {
            return HttpClient.DoRequestAsync<TrafficInformation>("api2/trafficsituation.json");
        }
    }
}
