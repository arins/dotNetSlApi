using System;

namespace SlApi.Models
{
    
    public class BaseResponse
    {
        public StatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public long ExecutionTime { get; set; }

    }
}
