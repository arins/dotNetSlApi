namespace SlApi.General.Models
{
    public class GeneralVersionTypeBaseResponse<T> : ArrayBaseResult<T>
    {
        /// <summary>
        /// Senast ändrad. Uppdateras normalt sett bara en gång per dygn
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Anger typen av datamodellen som svaret innehåller:
        /// Site, StopPoint, Line, JourneyPatternPointOfLine, TransportMode
        /// </summary>
        public string Type { get; set; }
        
    }
}
