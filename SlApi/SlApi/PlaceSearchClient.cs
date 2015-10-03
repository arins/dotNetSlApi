using System.Threading.Tasks;
using SlApi.General;
using SlApi.General.Core;
using SlApi.General.Models.PlaceSearch.Request;
using SlApi.General.Models.PlaceSearch.Response;

namespace SlApi
{
   
    public class PlaceSearchClient : BaseService, IPlaceSearchClient
    {
        public PlaceSearchClient(IHttpClient httpClient) : base(httpClient)
        {
        }

        public PlaceSearchClient(string endPoint)
            : base(new HttpClient(endPoint, new HttpRequester(), new UrlHelper()))
        {
        }
        public PlaceSearchClient()
            : base(new HttpClient("https://api.sl.se/", new HttpRequester(), new UrlHelper()))
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
