using System.Threading.Tasks;
using SlApi.Core;
using SlApi.Models.PlaceSearch.Request;
using SlApi.Models.PlaceSearch.Response;

namespace SlApi
{
   
    public class PlaceSearchClient : BaseService, IPlaceSearchClient
    {
        public PlaceSearchClient(IHttpClient httpClient) : base(httpClient)
        {
        }

        public PlaceSearchClient()
            : base(new HttpClient(new HttpRequester()))
        {
        }

       
        public Sites Search(PlaceSearchRequest placeSearchRequest)
        {
            return HttpClient.DoRequest<Sites>("api2/typeahead.json", placeSearchRequest);
        }

       
        public Task<Sites> SearchAsync(PlaceSearchRequest placeSearchRequest)
        {
            return HttpClient.DoRequestAsync<Sites>("api2/typeahead.json", placeSearchRequest);
        }
    }
}
