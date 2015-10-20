using System.Threading.Tasks;
using SlApi.Core;
using SlApi.Models.PlaceSearch.Request;
using SlApi.Models.PlaceSearch.Response;

namespace SlApi
{
   
    public class PlaceSearchClient : BaseService, IPlaceSearchClient
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

        public PlaceSearchClient(IHttpClient httpClient) : base(httpClient)
        {
        }

        public PlaceSearchClient(string apiToken, string endPoint = Endpoint)
            : base(new HttpClient(endPoint, new HttpRequester(), new UrlHelper()) {
                ApiToken = apiToken
            })
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
