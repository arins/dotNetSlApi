using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlApi.Models.StopsAndRoutes.Response
{
    public class TransportModes : BaseResponse
    {
        public StopsAndRoutesBaseResponse<TransportMode> ResponseData { get; set; }
    }
}
