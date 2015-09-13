using Newtonsoft.Json;
using SlApi.Models.RealtimeInformation.Response;

namespace SlApi.Models.TravelPlanner.Response
{
    /// <summary>
    /// Leg-objektet är en del av enresa. Det kanvara antingen en gångväg,
    ///  cykel eller bilväg eller oftast enresa med bus, tåg, eller annattyp av transportmedel.
    /// </summary>
    public class Leg
    {
        /// <summary>
        /// Sorterings rad
        /// </summary>
        public int Idx { get; set; }

        /// <summary>
        /// Beskrivning av transportTyp, t.ex. ”Tunnelbanans röda linje 14.”
        /// </summary>
        public string Name { get; set; }
        public TransportModeEnum Type { get; set; }

        /// <summary>
        /// Antal meter att gå.
        /// </summary>
        public int Distance { get; set; }

        /// <summary>
        /// Om t.ex. Pendeltåg, så är det riktningen pendeltåget åker mot, t.ex. Märsta/Bålsta etc.
        /// </summary>
        [JsonProperty("dir")]
        public string Direction { get; set; }

        /// <summary>
        /// Linjenummret, t.ex. 35.
        /// </summary>
        public string Linenumber { get; set; }

        /// <summary>
        /// Origin innehåller information om vart en delresa startar.
        /// </summary>
        public LegPlace Origin { get; set; }

        /// <summary>
        /// Destination innehåller information om vart en delresa slutar.
        /// </summary>
        public LegPlace Destination { get; set; }


        /// <summary>
        /// Innehåller en referens som kan användas som parameter till JourneyDetailRef-servicen.
        /// Svaret i denna använder Origin.routeIdx samt Destination.routeIdx för att veta från och
        ///  till delen i listan, då listan är en komplett lista på rutten.
        /// </summary>
        public LegRef JourneyDetailRef { get; set; }

        /// <summary>
        /// Innehåller en referens som kan användas som parameter till GeometryRef-servicen.
        /// </summary>
        public LegRef GeometryRef { get; set; }

    }
}