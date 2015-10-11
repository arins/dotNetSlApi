namespace SlApi.Models.RealtimeInformation.Response
{
    public class Bus : RealtimeInformationBase
    {
        /// <summary>
        /// Anger om det är en blå buss. Om det är en blå buss står det ”blåbuss”, annars är strängen tom.
        /// </summary>
        public string GroupOfLine { get; set; }

        /// <summary>
        /// Ytterligare identifierare för stoppställe, t.ex. bokstav för busskur eller spår för pendeltåg.
        /// </summary>
        public string StopPointDesignation { get; set; }
    }
}
