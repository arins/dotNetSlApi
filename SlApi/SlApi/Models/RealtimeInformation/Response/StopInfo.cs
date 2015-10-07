namespace SlApi.Models.RealtimeInformation.Response
{
    public class StopInfo : TransportModeContainer
    {
        public string GroupOfLine { get; set; }
        public string StopAreaName { get; set; }
        public int StopAreaNumber { get; set; }
        
    }
}