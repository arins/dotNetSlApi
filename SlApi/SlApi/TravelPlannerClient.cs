using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SlApi.Core;
using SlApi.Models.TrafficDeviationInformation.Request;
using SlApi.Models.TrafficDeviationInformation.Response;
using SlApi.Models.TrafficInformation.Response;
using SlApi.Models.TravelPlanner.Request;
using SlApi.Models.TravelPlanner.Response;

namespace SlApi
{

    public class TravelPlannerClient : BaseService
    {
        public TravelPlannerClient(IHttpClient httpClient) : base(httpClient)
        {
        }

        public TravelPlannerClient()
            : base(new HttpClient(new HttpRequester()))
        {
        }

       

        public TripResponse Trip(TripRequest tripRequest)
        {
            return HttpClient.DoRequest<TripResponse>("api2/TravelplannerV2/trip.json", tripRequest);
        }

        public Task<TripResponse> TripAsync(TripRequest tripRequest)
        {
            return HttpClient.DoRequestAsync<TripResponse>("api2/TravelplannerV2/trip.json", tripRequest);
        }

        public JourneyDetailResponse JourneyDetail(JourneyRequest journeyRequest)
        {
            return HttpClient.DoRequest<JourneyDetailResponse>("api2/TravelplannerV2/journeydetail.json", journeyRequest);
        }


        public Task<JourneyDetailResponse> JourneyDetailAsync(JourneyRequest journeyRequest)
        {
            return HttpClient.DoRequestAsync<JourneyDetailResponse>("api2/TravelplannerV2/journeydetail.json", journeyRequest);

        }

        public Task<GeometryResponse> GeometryAsync(GeometryRequest geometryRequest)
        {
            return HttpClient.DoRequestAsync<GeometryResponse>("api2/TravelplannerV2/geometry.json", geometryRequest);
        }

        public GeometryResponse Geometry(GeometryRequest geometryRequest)
        {
            return HttpClient.DoRequest<GeometryResponse>("api2/TravelplannerV2/geometry.json", geometryRequest);
        }
    }

    public class GeometryRequest : IConvertableToArgument
    {
        public string Ref { get; set; }
        public Arguments GetArgument()
        {
            var result = new Arguments();
            if (!string.IsNullOrEmpty(Ref))
            {
                result.Add("ref", Ref);
            }
            else
            {
                throw new ArgumentException("Ref must be set");
            }
            return result;
        }
    }

    public class GeometryResponse : TravelPlannerErrorResponse
    {
        public Geometry Geometry { get; set; }
    }

    public class Geometry
    {
        public string NoNamespaceSchemaLocation { get; set; }

        public Points Points { get; set; }
    }

    public class Points
    {
        [JsonConverter(typeof(SingleOrArrayConverter<Point>))]
        public List<Point> Point { get; set; }
    }

    public class Point
    {
        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("lon")]
        public double Longitude { get; set; }
    }
}
