using SlApi.Core;

namespace SlApi.Models.StopsAndRoutes.Request
{
    public class JourneyPatternPointOnLineRequest : IConvertableToArgument
    {
        public Arguments GetArgument()
        {
            var result = new Arguments { { "model", "jour" } };
            return result;
        }
    }
}
