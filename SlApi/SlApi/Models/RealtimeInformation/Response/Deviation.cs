namespace SlApi.Models.RealtimeInformation.Response
{
    public class Deviation
    {
        /// <summary>
        /// Konsekvensbeskrivning för aktuell avvikelse.
        /// </summary>
        public string Consequence { get; set; }
        /// <summary>
        /// Konsekvensbeskrivning för aktuell avvikelse.
        /// </summary>
        public int ImportanceLevel { get; set; }
        /// <summary>
        /// Beskrivning av aktuell avvikelse.
        /// </summary>
        public string Text { get; set; }
    }
}
