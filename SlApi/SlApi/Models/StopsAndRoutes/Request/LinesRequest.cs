using SlApi.Core;

namespace SlApi.Models.StopsAndRoutes.Request
{
    public class LinesRequest : IConvertableToArgument
    {
        public Arguments GetArgument()
        {
            var result = new Arguments { { "model", "line" } };
            return result;
        }
    }
}