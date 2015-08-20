using System;

namespace SlApi.Models
{
    
    public class BaseResponse
    {
        /// <summary>
        /// 0 om anropet har gått bra, annars en felkod som inte kan åtgärdas via tex ett modifierat anrop
        /// </summary>
        public StatusCode StatusCode { get; set; }

        public string Message { get; set; }
        public long ExecutionTime { get; set; }


    }
}
