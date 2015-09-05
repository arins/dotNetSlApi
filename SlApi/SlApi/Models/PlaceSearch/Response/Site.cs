namespace SlApi.Models.PlaceSearch.Response
{
    
    public class Site
    {
        /// <summary>
        /// Namnet på platsen.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Id för hållplatsområde.
        /// </summary>
        public int SiteId { get; set; }

        /// <summary>
        /// Typ av plats: ”Station”, ”Address” eller ”Poi” (Point of interest).
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// X-koordinat för placering.
        /// </summary>
        public string X { get; set; }

        /// <summary>
        /// Latitude från X cordinat ex 17986731
        /// </summary>
        public double? Latitude => ParseSiteCordinateToDouble(X);

        /// <summary>
        /// Y-koordinat för placering.
        /// </summary>
        public string Y { get; set; }

        /// <summary>
        /// Longitutde från Y kordinat
        /// </summary>
        public double? Longitude => ParseSiteCordinateToDouble(Y);


        private double? ParseSiteCordinateToDouble(string coordinate)
        {
            if (string.IsNullOrEmpty(coordinate))
            {
                return null;
            }

            long validLong;
            if (!long.TryParse(coordinate, out validLong))
            {
                return null;
            }
            var length = coordinate.Length;
            var parseThis = coordinate;
            if (length != 8 && length < 8)
            {
                var numberOfZerosToAdd = 8 - length;
                while (numberOfZerosToAdd > 0)
                {
                    parseThis = "0" + parseThis;
                    numberOfZerosToAdd--;
                }
            }
            parseThis = parseThis.Substring(0, 2) + "." + parseThis.Substring(2);
            double validDouble;
            if (double.TryParse(parseThis, out validDouble))
            {
                return validDouble;


            }
            return null;
        }
    }

}
