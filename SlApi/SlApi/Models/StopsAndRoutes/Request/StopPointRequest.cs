using SlApi.Core;

namespace SlApi.Models.StopsAndRoutes.Request
{
    public class StopPointRequest : IConvertableToArgument
    {
        public Arguments GetArgument()
        {
            var result = new Arguments { { "model", "stopPoint" } };
            return result;
        }
    }
}
