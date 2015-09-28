using SlApi.General.Core;

namespace SlApi.General.Models.StopsAndRoutes.Request
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
