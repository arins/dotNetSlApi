namespace SlApi.General.Models.RealtimeInformation.Response
{
    public class Train :RealtimeInformationBase
    {
        /// <summary>
        /// Namn på delmål.
        /// </summary>
        public string SecondaryDestinationName { get; set; }

        /// <summary>
        /// Ytterligare identifierare för stoppställe, t.ex. bokstav för busskur eller spår för pendeltåg.
        /// </summary>
        public string StopPointDesignation { get; set; }
    }
}
