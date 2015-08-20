using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlApi.Models.StopsAndRoutes.Response
{
    public class Lines : BaseResponse
    {
        public StopsAndRoutesBaseResponse<Line> ResponseData { get; set; }
    }
}
