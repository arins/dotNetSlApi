using System.Threading.Tasks;
using SlApi.Core;
using SlApi.Models.RealtimeInformation.Request;
using SlApi.Models.RealtimeInformation.Response;

namespace SlApi
{
    public class RealtimeInformationClient : BaseService, IRealtimeInformationClient
    {

        public bool GzipEnabled
        {
            get
            {
                return HttpClient.Requester.GzipEnabled;
            }
            set { HttpClient.Requester.GzipEnabled = value; }
        }

        public bool EnableDebugInformationInException
        {
            get { return HttpClient.EnableDebugInformationInException; }
            set { HttpClient.EnableDebugInformationInException = value; }
        }

        public RealtimeInformationClient(IHttpClient httpClient)
            : base(httpClient)
        {
        }

     

        public RealtimeInformationClient(string apiToken, string endPoint = Endpoint)
            : base(new HttpClient(endPoint, new HttpRequester(), new UrlHelper()))
        {
            ApiToken = apiToken;
        }
        public RealtimeInformationClient()
            : base(new HttpClient("https://api.sl.se/", new HttpRequester(), new UrlHelper()))
        {
        }

        public DepartureResponse RealtimeDepartures(RealtimeDeparturesRequest realTimeSearchRequest)
        {
            return HttpClient.DoRequest<DepartureResponse>("api2/realtimedepartures.json", realTimeSearchRequest);
        }

        public Task<DepartureResponse> RealtimeDeparturesAsync(RealtimeDeparturesRequest realTimeSearchRequest)
        {
            return HttpClient.DoRequestAsync<DepartureResponse>("api2/realtimedepartures.json", realTimeSearchRequest);
        }
    }
}
