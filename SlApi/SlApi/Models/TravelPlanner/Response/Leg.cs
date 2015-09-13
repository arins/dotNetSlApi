using Newtonsoft.Json;
using SlApi.Models.RealtimeInformation.Response;

namespace SlApi.Models.TravelPlanner.Response
{
    /// <summary>
    /// Leg-objektet �r en del av enresa. Det kanvara antingen en g�ngv�g,
    ///  cykel eller bilv�g eller oftast enresa med bus, t�g, eller annattyp av transportmedel.
    /// </summary>
    public class Leg
    {
        /// <summary>
        /// Sorterings rad
        /// </summary>
        public int Idx { get; set; }

        /// <summary>
        /// Beskrivning av transportTyp, t.ex. �Tunnelbanans r�da linje 14.�
        /// </summary>
        public string Name { get; set; }
        public TransportModeEnum Type { get; set; }

        /// <summary>
        /// Antal meter att g�.
        /// </summary>
        public int Distance { get; set; }

        /// <summary>
        /// Om t.ex. Pendelt�g, s� �r det riktningen pendelt�get �ker mot, t.ex. M�rsta/B�lsta etc.
        /// </summary>
        [JsonProperty("dir")]
        public string Direction { get; set; }

        /// <summary>
        /// Linjenummret, t.ex. 35.
        /// </summary>
        public string Linenumber { get; set; }

        /// <summary>
        /// Origin inneh�ller information om vart en delresa startar.
        /// </summary>
        public LegPlace Origin { get; set; }

        /// <summary>
        /// Destination inneh�ller information om vart en delresa slutar.
        /// </summary>
        public LegPlace Destination { get; set; }


        /// <summary>
        /// Inneh�ller en referens som kan anv�ndas som parameter till JourneyDetailRef-servicen.
        /// Svaret i denna anv�nder Origin.routeIdx samt Destination.routeIdx f�r att veta fr�n och
        ///  till delen i listan, d� listan �r en komplett lista p� rutten.
        /// </summary>
        public LegRef JourneyDetailRef { get; set; }

        /// <summary>
        /// Inneh�ller en referens som kan anv�ndas som parameter till GeometryRef-servicen.
        /// </summary>
        public LegRef GeometryRef { get; set; }

    }
}