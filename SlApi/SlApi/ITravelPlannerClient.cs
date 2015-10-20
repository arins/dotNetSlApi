using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlApi.Models.TravelPlanner.Request;
using SlApi.Models.TravelPlanner.Response;

namespace SlApi
{
    public interface ITravelPlannerClient

    {

        bool EnableDebugInformationInException { get; set; }
        bool GzipEnabled
        {
            get; set;
        }
        GeometryResponse Geometry(GeometryRequest geometryRequest);
        Task<GeometryResponse> GeometryAsync(GeometryRequest geometryRequest);
        JourneyDetailResponse JourneyDetail(JourneyRequest journeyRequest);
        Task<JourneyDetailResponse> JourneyDetailAsync(JourneyRequest journeyRequest);
        TripResponse Trip(TripRequest tripRequest);
        Task<TripResponse> TripAsync(TripRequest tripRequest);
    }
}
