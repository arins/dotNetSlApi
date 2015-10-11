namespace SlApi.Models.TravelPlanner.Response
{
    public class PriceInfo
    {
        /// <summary>
        /// Innehåller en lista av tariff-relaterad information som kan visas tillsammans med prisinformationen.
        /// </summary>
        public TariffZones TariffZones { get; set; }
        
        /// <summary>
        /// Tariff beskrivning.
        /// </summary>
        public TariffRemark TariffRemark { get; set; }
    }
}