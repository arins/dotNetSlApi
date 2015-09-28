namespace SlApi.General.Models.NearbyStations.Response
{
    public class LocationList : ErrorResponse
    {
        public StopLocation[] StopLocation { get; set; }
        public string NoNamespaceSchemaLocation { get; set; }
        
    }
}