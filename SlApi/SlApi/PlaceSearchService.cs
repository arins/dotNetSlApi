using System.Threading.Tasks;
using SlApi.Core;
using SlApi.Models.PlaceSearch.Request;
using SlApi.Models.PlaceSearch.Response;

namespace SlApi
{
    public class PlaceSearchService : BaseService
    {
        public PlaceSearchService(IClient client) : base(client)
        {
        }

        public PlaceSearchService()
            : base(new Client(new HttpRequester()))
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
