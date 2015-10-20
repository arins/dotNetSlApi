using System.Threading.Tasks;
using SlApi.Core;
using SlApi.Models.TrafficDeviationInformation.Request;
using SlApi.Models.TrafficDeviationInformation.Response;

namespace SlApi
{

    public class TrafficDeviationInformationClient : BaseService, ITrafficDeviationInformationClient
    {

        public bool GzipEnabled
        {
            get
            {
                return HttpClient.Requester.GzipEnabled;

            }
            set
            {
                HttpClient.Requester.GzipEnabled = value;
            }
        }

        public bool EnableDebugInformationInException
        {
            get { return HttpClient.EnableDebugInformationInException; }
            set { HttpClient.EnableDebugInformationInException = value; }
        }

        public TrafficDeviationInformationClient(IHttpClient httpClient) : base(httpClient)
        {
        }

       
        public TrafficDeviationInformationClient(string apiToken, string endPoint = Endpoint)
            : base(new HttpClient(endPoint, new HttpRequester(), new UrlHelper()))
        {
            ApiToken = apiToken;
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
