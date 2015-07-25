using System.Threading.Tasks;
using SlApi.Core;
using SlApi.Models.Request;
using SlApi.Models.Response;

namespace SlApi
{
    public class PlaceSearchService : BaseService
    {
        public PlaceSearchService(IClient client) : base(client)
        {
        }

        public Sites Search(SearchRequest searchRequest)
        {
            return Client.DoRequest<Sites>("api2/typeahead.json", searchRequest);
        }

        public async Task<Sites> SearchAsync(SearchRequest searchRequest)
        {
            return await Client.DoRequestAsync<Sites>("api2/typeahead.json", searchRequest);
        }
    }
}
