using System.Text;
using SlApi.Core;

namespace SlApi.Models.StopsAndRoutes.Request
{
    public class LineDataRequest : IConvertableToArgument
    {
        public Arguments GetArgument()
        {
            var result = new Arguments { { "model", "site" }};
            return result;
        }
    }
}