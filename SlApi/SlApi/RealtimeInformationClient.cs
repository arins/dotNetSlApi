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

        public RealtimeInformationClient() : base(new HttpClient(new HttpRequester()))
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
