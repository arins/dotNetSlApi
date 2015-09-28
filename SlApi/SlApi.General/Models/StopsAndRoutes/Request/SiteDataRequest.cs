using SlApi.General.Core;

namespace SlApi.General.Models.StopsAndRoutes.Request
{
    public class SiteDataRequest : IConvertableToArgument
    {
        public Arguments GetArgument()
        {
            var result = new Arguments { { "model", "site" }};
            return result;
        }
    }
}