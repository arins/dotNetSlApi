using SlApi.General.Core;

namespace SlApi.General.Models.StopsAndRoutes.Request
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
