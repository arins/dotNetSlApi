using System.Threading.Tasks;
using SlApi.General;
using SlApi.General.Core;
using SlApi.General.Models.TrafficDeviationInformation.Request;
using SlApi.General.Models.TrafficDeviationInformation.Response;

namespace SlApi
{

    public class TrafficDeviationInformationClient : BaseService, ITrafficDeviationInformationClient
    {
        public TrafficDeviationInformationClient(IHttpClient httpClient) : base(httpClient)
        {
        }

       
        public TrafficDeviationInformationClient(string endPoint)
            : base(new HttpClient(endPoint, new HttpRequester(), new UrlHelper()))
        {
        }
        public TrafficDeviationInformationClient()
            : base(new HttpClient("https://api.sl.se/", new HttpRequester(), new UrlHelper()))
        {
        }
        public TrafficDeviationInformation GetTrafficDeviationInformation(TrafficDeviationInformationRequest request)
        {
            return HttpClient.DoRequest<TrafficDeviationInformation>("api2/deviations.json", request);
        }


        public Task<TrafficDeviationInformation> GetTrafficDeviationInformationAsync(TrafficDeviationInformationRequest request)
        {
            return HttpClient.DoRequestAsync<TrafficDeviationInformation>("api2/deviations.json", request);
        }



        public TrafficDeviationInformationRaw GetTrafficDeviationInformationRaw(TrafficDeviationInformationRawRequest request)
        {
            return HttpClient.DoRequest<TrafficDeviationInformationRaw>("api2/deviationsrawdata.json");
        }


        public Task<TrafficDeviationInformationRaw> GetTrafficDeviationInformationRawAsync(TrafficDeviationInformationRawRequest request)
        {
            return HttpClient.DoRequestAsync<TrafficDeviationInformationRaw>("api2/deviationsrawdata.json");
        }
    }
}
