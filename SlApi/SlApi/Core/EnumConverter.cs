using SlApi.Models.StopsAndRoutes.Response;

namespace SlApi.Core
{
    public static class EnumConverter
    {
        public static string ToNearbyStationsRequestString(this Language lang)
        {
            switch (lang)
            {
                case Language.English:
                    return "en";
                case Language.Swedish:
                    return "sv";
                default:
                    return "sv";
            }
        }

        public static string ToTripLanguageString(this Language lang)
        {
            return ToNearbyStationsRequestString(lang);
        }

        public static string ToTrafficDeviationInformationString(this DefaultTransportModeCode transportMode)
        {
            switch (transportMode)
            {
                case DefaultTransportModeCode.Bus:
                    return "bus";
                case DefaultTransportModeCode.Ferry:
                    return "ferry";
                case DefaultTransportModeCode.Metro:
                    return "metro";
                case DefaultTransportModeCode.Ship:
                    return "ship";
                case DefaultTransportModeCode.Train:
                    return "train";
                case DefaultTransportModeCode.Tram:
                    return "tram";
                default:
                    return "";
            }
        }
    }
}