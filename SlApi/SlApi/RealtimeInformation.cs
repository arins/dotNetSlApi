using System.Threading.Tasks;
using SlApi.Core;
using SlApi.Models.RealtimeInformation.Request;
using SlApi.Models.RealtimeInformation.Response;

namespace SlApi
{
    public class RealtimeInformation : BaseService
    {
        public RealtimeInformation(IClient client)
            : base(client)
        {
        }

        public RealtimeInformation() : base(new Client(new HttpRequester()))
        {
            
        }

        public DepartureResponse RealtimeDepartures(RealtimeDeparturesRequest searchRequest)
        {
            return Client.DoRequest<DepartureResponse>("api2/realtimedepartures.json", searchRequest);
        }

        public async Task<DepartureResponse> RealtimeDeparturesAsync(RealtimeDeparturesRequest searchRequest)
        {
            return await Client.DoRequestAsync<DepartureResponse>("api2/realtimedepartures.json", searchRequest);
        }
    }
}
