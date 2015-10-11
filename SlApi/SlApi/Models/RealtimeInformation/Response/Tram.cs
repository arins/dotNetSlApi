namespace SlApi.Models.RealtimeInformation.Response
{
    public class Tram : RealtimeInformationBase
    {
        /// <summary>
        /// 
        /// Linjegrupp, t.ex. “Tvärbanan” eller “Roslagsbanan”.
        /// </summary>
        public string GroupOfLine { get; set; }

        /// <summary>
        /// Ytterligare identifierare för stoppställe, t.ex. bokstav för busskur eller spår för pendeltåg.
        /// </summary>
        public string StopPointDesignation { get; set; }
        
    }
}