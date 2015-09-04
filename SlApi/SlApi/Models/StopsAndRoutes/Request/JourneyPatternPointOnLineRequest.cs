using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
