namespace SlApi.Models
{
    public enum StatusCode
    {

        Ok = 0,

        /// <summary>
        /// Nyckel hare ej skickats med.
        /// </summary>
        ApiKeyUndefined = 1001,
        /// <summary>
        /// Nyckel är ogiltig
        /// </summary>
        KeyIsInvalid = 1001,

        /// <summary>
        /// problem with request: Key is invalid
        /// Nyckel är ogiltig
        /// </summary>
        KeyIsInvalid2 = 1002,

        /// <summary>
        /// Ogiltigt api
        /// </summary>
        InvalidApi = 1003,

        /// <summary>
        /// This api is currently not available for keys with priority above 2
        /// </summary>
        NotAvailableForLowPrioKeys= 1004,

        /// <summary>
        /// Nyckel finns, men ej för detta api
        /// </summary>
        KeyNotValidForThisApi = 1005,

        /// <summary>
        /// För många anrop per minut, för den profil som används
        /// </summary>
        ToManyRequestsPerMinute = 1006,

        /// <summary>
        /// För många anrop per månad, för den profil som används
        /// </summary>
        ToManyRequestsPerMonth = 1007,


        /// <summary>
        /// Ett ospecificerat fel har genererats i bakomloggande api.
        /// </summary>
        ProxyError = 1008,


        /// <summary>
        /// SiteId måste gå att konvertera till heltal.
        /// </summary>
        SiteIdNotAnInteger = 4001,

        /// <summary>
        /// Fråndatum angett utan tilldatum. Båda datumen måste vara angivna vid filtrering på datum.
        /// </summary>
        DateFromAndToInvalid = 4002,

        /// <summary>
        /// Serverfel
        /// </summary>
        ServerError = 5000,

        /// <summary>
        /// Kunde varken hämta information från TPI (tunnelbanan) eller DPS (övriga trafikslag).
        /// </summary>
        CouldNotFetchDataFromTpiAndDps = 5321,

        /// <summary>
        /// Kunde inte hämta information från DPS.
        /// </summary>
        CouldNotFetchDataFromDps = 5322,

        /// <summary>
        /// Kunde inte hämta information från TPI.
        /// </summary>
        CouldNotFetchDataFromTpi = 5323,

        /// <summary>
        /// Kunde varken hämta information från TPI (tunnelbanan) eller DPS
        ///  (övriga trafikslag) p.g.a. inaktuell DPS-data. Detta uppstår om DPS-datan är äldre än 2 minuter vid svarstillfället.
        /// </summary>
        DpsDataToOld = 5324,


    }
}