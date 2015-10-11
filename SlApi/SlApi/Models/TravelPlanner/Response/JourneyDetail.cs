namespace SlApi.Models.TravelPlanner.Response
{
    public class JourneyDetail
    {
        public string NoNamespaceSchemaLocation { get; set; }
        public Stops Stops { get; set; }

        public ApiRef GeometryRef { get; set; }

        public JourneyNames Names { get; set; }

        public JourneyTypes Types { get; set; }

        public JourneyLines Lines { get; set; }

        public JourneyDirections Directions { get; set; }

        
        public RtuMessages RtuMessages { get; set; }
    }
}