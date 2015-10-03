using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlApi.General.Models.TravelPlanner.Request;
using SlApi.General.Models.TravelPlanner.Response;

namespace SlApi.General
{
    public interface ITravelPlannerClient

    {
        GeometryResponse Geometry(GeometryRequest geometryRequest);
        Task<GeometryResponse> GeometryAsync(GeometryRequest geometryRequest);
        JourneyDetailResponse JourneyDetail(JourneyRequest journeyRequest);
        Task<JourneyDetailResponse> JourneyDetailAsync(JourneyRequest journeyRequest);
        TripResponse Trip(TripRequest tripRequest);
        Task<TripResponse> TripAsync(TripRequest tripRequest);
    }
}
