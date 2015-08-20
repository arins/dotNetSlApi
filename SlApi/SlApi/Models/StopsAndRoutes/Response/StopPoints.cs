using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlApi.Models.StopsAndRoutes.Response
{
    public class StopPoints : BaseResponse
    {
        public StopsAndRoutesBaseResponse<StopPoint> ResponseData { get; set; }
    }
}
