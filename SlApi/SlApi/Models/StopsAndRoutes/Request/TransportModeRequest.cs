using SlApi.Core;

namespace SlApi.Models.StopsAndRoutes.Request
{
    public class TransportModeRequest : IConvertableToArgument
    {
        public Arguments GetArgument()
        {
            var result = new Arguments { { "model", "tran" } };
            return result;
        }
    }
}
