namespace SlApi.General.Models
{
    
    public class BaseResponse
    {
        /// <summary>
        /// 0 om anropet har gått bra, annars en felkod som inte kan åtgärdas via tex ett modifierat anrop
        /// </summary>
        public StatusCode StatusCode { get; set; }


        /// <summary>
        /// Innehåller eventuellt anropsrelaterade meddelanden som t.ex. felmeddelanden. Se ”Felmeddelanden” nedan.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Anger hur lång tid (i ms) det tog för servern att generera svaret.
        /// </summary>
        public long ExecutionTime { get; set; }


    }

    public class BaseResponse<T> : BaseResponse
    {
        public T ResponseData { get; set; }
    }

    public class BaseResponseWithVersionType<T> : BaseResponse
    {
        public GeneralVersionTypeBaseResponse<T> ResponseData { get; set; }
    }
}
