using System.Linq;

namespace SlApi.Models.TrafficInformation.Response
{
    public class TrafficType
    {

        public int Id { get; set; }
        /// <summary>
        /// Namn på trafikslag: "Tunnelbana", "Pendeltåg", etc.
        /// </summary>
        public string Name { get; set; }

        public TraficTypeEnum Type { get; set; }

        /// <summary>
        /// Hjälpinformation som indikerar vilken ikon som ska visas i webben.
        /// </summary>
        public string StatusIcon { get; set; }

        /// <summary>
        /// Hjälpinformation som indikerar om informationen har hög prioritet eller inte.
        /// </summary>
        public bool Expanded { get; set; }

        /// <summary>
        /// Hjälpinformation som indikerar om det finns planerade händelser.
        /// </summary>
        public bool HasPlannedEvent { get; set; }

        /// <summary>
        /// Ett TrafficEvent objekt för varje händelse.
        /// </summary>
        public TrafficEvent[] Events { get; set; }
    }

    public class TrafficEvent
    {
        /// <summary>
        /// Löpnummer på händelsen.
        /// </summary>
        public int EventId { get; set; }

        /// <summary>
        /// Meddelande gällande störningen/händelsen.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Hjälpinformation som indikerar om informationen har hög prioritet eller inte.
        /// </summary>
        public bool Expanded { get; set; }

        /// <summary>
        /// Hjälpinformation som indikerar om händelsen är planerad eller inte. 
        /// </summary>
        public bool Planned { get; set; }

        /// <summary>
        /// Sorteringsordning på händelsen.
        /// </summary>
        public int SortIndex { get; set; }

        /// <summary>
        /// Hjälpinformation som indikerar vilken ikon som ska visas i webben.
        /// </summary>
        public string StatusIcon { get; set; }

        /// <summary>
        /// Linjenummer som händelsen berör, en kommaseparerad String t.ex. ”177, 69K, 508”.
        /// </summary>
        public LineNumbers LineNumbers { get; set; }
        

        /// <summary>
        /// Namn på den bana som händelsen påverkar. Kan saknas, om händelsen påverkar hela trafikslaget eller banor inte finns (typ bussar).
        /// </summary>
        public string TrafficLine { get; set; }

        /// <summary>
        /// Länk till storningsinformation.sl.se, eller till specifik sida med information om händelsen.
        /// </summary>
        public string EventInfoUrl { get; set; }

    }

    public class LineNumbers
    {
        

        /// <summary>
        /// Är alltid satt till True och indikerar att linjenummer är frivilligt.
        /// </summary>
        public bool InputDataIsOptional { get; set; }


        /// <summary>
        /// Linjenummer som händelsen berör, en kommaseparerad String t.ex. ”177, 69K, 508”.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// LineNumbers fast som array
        /// </summary>
        public string[] LineNumbersAsArray
        {
            get
            {
                if (string.IsNullOrEmpty(Text))
                {
                    return new string[0];
                }
                return Text.Split(',').Select(x => x.Trim()).ToArray();
            }
        }
    }
}