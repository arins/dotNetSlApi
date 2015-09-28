using SlApi.General.Core;

namespace SlApi.General.Models.StopsAndRoutes.Request
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
