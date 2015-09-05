namespace SlApi.Core
{
    public static class LanguageEnumConverter
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
    }
}