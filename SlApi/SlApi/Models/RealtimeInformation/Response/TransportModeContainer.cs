using Newtonsoft.Json;

namespace SlApi.Models.RealtimeInformation.Response
{
    public class TransportModeContainer
    {
        /// <summary>
        /// Trafikslag: ”BUS”, ”TRAIN”, ”TRAM” eller ”SHIP”.
        /// </summary>
        
        public string TransportMode { get; set; }

        [JsonIgnore]
        public TransportModeEnum TransportModeEnum
        {
            get
            {
                switch (TransportMode)
                {
                    case "BUS":
                        return TransportModeEnum.Bus;
                    case "TRAIN":
                        return TransportModeEnum.Train;
                    case "TRAM":
                        return TransportModeEnum.Tram;
                    case "METRO":
                        return TransportModeEnum.Metro;
                    default:
                        return TransportModeEnum.Ship;
                }
            }
            set
            {
                switch (value)
                {
                    case TransportModeEnum.Bus:
                        TransportMode = "BUS";
                        break;
                    case TransportModeEnum.Train:
                        TransportMode = "TRAIN";
                        break;
                    case TransportModeEnum.Tram:
                        TransportMode = "TRAM";
                        break;
                    case TransportModeEnum.Metro:
                        TransportMode = "METRO";
                        break;
                    default:
                        TransportMode = "SHIP";
                        break;
                }
            }
        }
    }
}