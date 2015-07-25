using System;

namespace SlApi.Models
{
    [Serializable]
    public class BaseResponse
    {
        public StatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public long ExecutionTime { get; set; }

    }
}
