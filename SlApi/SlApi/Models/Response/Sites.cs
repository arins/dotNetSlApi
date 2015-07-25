using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlApi.Models.Response
{
    [Serializable]
    public class Sites : BaseResponse
    {
        public IEnumerable<Site> ResponseData { get; set; } 
    }
}
