using System.Linq;

namespace SlApi.Models.TrafficInformation.Response
{
    public class TrafficType
    {

        public int Id { get; set; }
        /// <summary>
        /// Namn p� trafikslag: "Tunnelbana", "Pendelt�g", etc.
        /// </summary>
        public string Name { get; set; }

        public TraficTypeEnum Type { get; set; }

        /// <summary>
        /// Hj�lpinformation som indikerar vilken ikon som ska visas i webben.
        /// </summary>
        public string StatusIcon { get; set; }

        /// <summary>
        /// Hj�lpinformation som indikerar om informationen har h�g prioritet eller inte.
        /// </summary>
        public bool Expanded { get; set; }

        /// <summary>
        /// Hj�lpinformation som indikerar om det finns planerade h�ndelser.
        /// </summary>
        public bool HasPlannedEvent { get; set; }

        /// <summary>
        /// Ett TrafficEvent objekt f�r varje h�ndelse.
        /// </summary>
        public TrafficEvent[] Events { get; set; }
    }

    public class TrafficEvent
    {
        /// <summary>
        /// L�pnummer p� h�ndelsen.
        /// </summary>
        public int EventId { get; set; }

        /// <summary>
        /// Meddelande g�llande st�rningen/h�ndelsen.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Hj�lpinformation som indikerar om informationen har h�g prioritet eller inte.
        /// </summary>
        public bool Expanded { get; set; }

        /// <summary>
        /// Hj�lpinformation som indikerar om h�ndelsen �r planerad eller inte. 
        /// </summary>
        public bool Planned { get; set; }

        /// <summary>
        /// Sorteringsordning p� h�ndelsen.
        /// </summary>
        public int SortIndex { get; set; }

        /// <summary>
        /// Hj�lpinformation som indikerar vilken ikon som ska visas i webben.
        /// </summary>
        public string StatusIcon { get; set; }

        /// <summary>
        /// Linjenummer som h�ndelsen ber�r, en kommaseparerad String t.ex. �177, 69K, 508�.
        /// </summary>
        public LineNumbers LineNumbers { get; set; }
        

        /// <summary>
        /// Namn p� den bana som h�ndelsen p�verkar. Kan saknas, om h�ndelsen p�verkar hela trafikslaget eller banor inte finns (typ bussar).
        /// </summary>
        public string TrafficLine { get; set; }

        /// <summary>
        /// L�nk till storningsinformation.sl.se, eller till specifik sida med information om h�ndelsen.
        /// </summary>
        public string EventInfoUrl { get; set; }

    }

    public class LineNumbers
    {
        

        /// <summary>
        /// �r alltid satt till True och indikerar att linjenummer �r frivilligt.
        /// </summary>
        public bool InputDataIsOptional { get; set; }


        /// <summary>
        /// Linjenummer som h�ndelsen ber�r, en kommaseparerad String t.ex. �177, 69K, 508�.
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