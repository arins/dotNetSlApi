namespace SlApi.General.Models.TravelPlanner.Response
{
    /// <summary>
    /// Rotelement, inneh�ller en lista med element av typen Trip.
    /// </summary>
    public class TripList : ErrorResponse
    {
        public string NoNamespaceSchemaLocation { get; set; }
       public Trip[] Trip { get; set; }

    }
}