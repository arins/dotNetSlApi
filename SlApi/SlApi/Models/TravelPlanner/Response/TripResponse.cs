namespace SlApi.Models.TravelPlanner.Response
{
    public class TripResponse : TravelPlannerErrorResponse
    {
        public TripList TripList { get; set; }
    }
}