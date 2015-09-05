using SlApi.Core;

namespace SlApi.Models.StopsAndRoutes.Request
{
    class TransportModeRequest : IConvertableToArgument
    {
        public Arguments GetArgument()
        {
            var result = new Arguments { { "model", "tran" } };
            return result;
        }
    }
}
