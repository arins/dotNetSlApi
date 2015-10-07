using System.Threading.Tasks;
using SlApi.Core;
using SlApi.Models.RealtimeInformation.Request;
using SlApi.Models.RealtimeInformation.Response;

namespace SlApi
{
    public class RealtimeInformationClient : BaseService, IRealtimeInformationClient
    {
        public RealtimeInformationClient(IHttpClient httpClient)
            : base(httpClient)
        {
        }

     

        public RealtimeInformationClient(string endPoint)
            : base(new HttpClient(endPoint, new HttpRequester(), new UrlHelper()))
        {
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
