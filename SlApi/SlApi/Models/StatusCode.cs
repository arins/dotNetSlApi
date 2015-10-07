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


        /// <summary>
        /// 
        /// </summary>
        S19 = 10000,


        /// <summary>
        /// Unknown service method
        /// </summary>
        R0001 = 10001,

        /// <summary>
        /// Invalid or missing request parameters.
        /// </summary>
        R0002 = 10002,

        /// <summary>
        /// Internal communication error.
        /// </summary>
        R0007 = 10007,

        /// <summary>
        /// Dep./Arr./Intermed. or equivalent stations defined more than once.
        /// </summary>
        H9380 = 19380,


        /// <summary>
        /// Error in data field.
        /// </summary>
        H9360 = 19360,

        /// <summary>
        /// The input is incorrect or incomplete.
        /// </summary>
        H9320 = 19320,


        /// <summary>
        /// Unknown arrival station.
        /// </summary>
        H9300 = 19300,

        /// <summary>
        /// Unknown intermediate station.
        /// </summary>
        H9280 = 19280,

        /// <summary>
        /// Unknown departure station.
        /// </summary>
        H9260 = 19260,

        /// <summary>
        /// Part inquiry interrupted.
        /// </summary>
        H9250 = 19250,

        /// <summary>
        /// Unsuccessful search.
        /// </summary>
        H9240 = 19240,

        /// <summary>
        /// An internal error occurred.
        /// </summary>
        H9230 = 19230,


        /// <summary>
        /// Nearby to the given address stations could not be found.
        /// </summary>
        H9220 = 19220,

        /// <summary>
        /// Unsuccessful or incomplete search (timetable change).
        /// </summary>
        H900 = 10900,


        /// <summary>
        /// Unsuccessful or incomplete search (timetable change).
        /// </summary>
        H899 = 10899,


        /// <summary>
        /// Departure/Arrival are too near.
        /// </summary>
        H895 = 10895,


        /// <summary>
        /// Inquiry too complex (try entering less intermediate stations).
        /// </summary>
        H892 = 10892,


        /// <summary>
        /// No route found (try entering an intermediate station).
        /// </summary>
        H891 = 10891,

        /// <summary>
        /// Unsuccessful search.
        /// </summary>
        H890 = 10890,

        /// <summary>
        /// Because of too many trains the connection is not complete.
        /// </summary>
        H500 = 10500,

        /// <summary>
        /// One or more stops are passed through multiple times.
        /// </summary>
        H460 = 10460,

        /// <summary>
        /// Prolonged stop.
        /// </summary>
        H455 = 10455,

        /// <summary>
        /// Display may be incomplete due to change of timetable.   
        /// </summary>
        H410 = 10410,

        /// <summary>
        /// Departure/Arrival replaced by an equivalent station.
        /// </summary>
        H390 = 10390



    }
}