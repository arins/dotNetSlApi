using System.Threading.Tasks;
using SlApi.Core;
using SlApi.Models.PlaceSearch.Request;
using SlApi.Models.PlaceSearch.Response;

namespace SlApi
{
    public class PlaceSearchClient : BaseService
    {
        public PlaceSearchClient(IHttpClient httpClient) : base(httpClient)
        {
        }

        public PlaceSearchClient()
            : base(new HttpClient(new HttpRequester()))
        {
        }

        public Sites Search(SearchRequest searchRequest)
        {
            return HttpClient.DoRequest<Sites>("api2/typeahead.json", searchRequest);
        }

        public async Task<Sites> SearchAsync(SearchRequest searchRequest)
        {
            return await HttpClient.DoRequestAsync<Sites>("api2/typeahead.json", searchRequest);
        }
    }
}
