using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlApi.Models.Response
{
    [Serializable]
    public class BaseResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public long ExecutionTime { get; set; }

    }
}
