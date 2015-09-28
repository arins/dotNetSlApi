namespace SlApi.General.Models.NearbyStations.Response
{
    public class StopLocation
    {
        /// <summary>
        /// Sorterings id. Löpnummer för sortering enligt avstånd till koordinaten.
        ///  Lägst idx är närmast koordinaten.
        /// </summary>
        public int Idx { get; set; }

        /// <summary>
        /// Namn för hållplats.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// HafasId för hållplatsen. Läs mer om HafasId i sektionen HafasId och SiteId.
        /// </summary>
        public string Id { get; set; }

        public string SiteId
        {
            get
            {
                if (!string.IsNullOrEmpty(Id) && Id.Length > 5)
                {
                    return Id.Substring(4);
                }
                return null;
            }
        }


        /// <summary>
        /// Lat (WGS, decimal degree), ex 59.293611
        /// </summary>
        public double Lat { get; set; }

        /// <summary>
        /// Long (WGS, decimal degree), ex 18.083056
        /// </summary>
        public double Lon { get; set; }

        /// <summary>
        /// Distans i meter från försedd koordinat i anropet.
        /// </summary>
        public int Dist { get; set; }



    }
}
