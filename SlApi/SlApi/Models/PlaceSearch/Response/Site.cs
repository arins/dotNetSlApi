namespace SlApi.Models.PlaceSearch.Response
{
    //todo add description to each field 
    //todo fix X,Y to double
    public class Site
    {
        public string Name { get; set; }
        public int SiteId { get; set; }
        public string Type { get; set; }
        public string X { get; set; }
        public string Y { get; set; }
    }
}
