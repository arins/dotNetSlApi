using System.Threading.Tasks;

using SlApi.Core;
using SlApi.Models.TrafficInformation.Response;

namespace SlApi
{

    public class TrafficInformationClient : BaseService, ITrafficInformationClient
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
        public TrafficInformationClient(IHttpClient httpClient) : base(httpClient)
        {
        }

        
        public TrafficInformationClient(string apiToken, string endPoint = Endpoint)
            : base(new HttpClient(endPoint, new HttpRequester(), new UrlHelper()))
        {
            ApiToken = apiToken;
        }
        public TrafficInformationClient()
            : base(new HttpClient("https://api.sl.se/", new HttpRequester(), new UrlHelper()))
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
