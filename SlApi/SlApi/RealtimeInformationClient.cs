using System.Threading.Tasks;
using SlApi.Core;
using SlApi.Models.RealtimeInformation.Request;
using SlApi.Models.RealtimeInformation.Response;

namespace SlApi
{
    public class RealtimeInformationClient : BaseService
    {
        public RealtimeInformationClient(IHttpClient httpClient)
            : base(httpClient)
        {
        }

        public RealtimeInformationClient() : base(new HttpClient(new HttpRequester()))
        {
            
        }

        public DepartureResponse RealtimeDepartures(RealtimeDeparturesRequest searchRequest)
        {
            return HttpClient.DoRequest<DepartureResponse>("api2/realtimedepartures.json", searchRequest);
        }

        public Task<DepartureResponse> RealtimeDeparturesAsync(RealtimeDeparturesRequest searchRequest)
        {
            return HttpClient.DoRequestAsync<DepartureResponse>("api2/realtimedepartures.json", searchRequest);
        }
    }
}
